using Application.Features.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Common.DomainAttribute;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
public class CsvImporterService : ICsvImporterService
{
    private readonly TestAppDbContext _db;

    public CsvImporterService(TestAppDbContext db)
    {
        _db = db;
    }

    public async Task ImportAsync<TEntity>(Stream csvStream, int batchSize = 500)
        where TEntity : class, new()
    {
        var keyProp = GetKeyProperty<TEntity>();
        if (keyProp == null)
            throw new Exception($"No property marked with [CsvKey] in {typeof(TEntity).Name}");

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            TrimOptions = TrimOptions.Trim
        };

        using var reader = new StreamReader(csvStream);
        using var csv = new CsvReader(reader, config);

        csv.Read();
        csv.ReadHeader();

        var header = csv.HeaderRecord;
        var props = typeof(TEntity).GetProperties()
            .Where(p => header.Contains(p.Name, StringComparer.OrdinalIgnoreCase))
            .ToDictionary(p => p.Name, p => p, StringComparer.OrdinalIgnoreCase);

        var batch = new List<TEntity>();

        while (csv.Read())
        {
            var entity = new TEntity();

            foreach (var col in header)
            {
                if (!props.TryGetValue(col, out var prop)) continue;

                var rawValue = csv.GetField(col);
                if (string.IsNullOrWhiteSpace(rawValue)) continue;

                var value = ConvertValue(rawValue, prop.PropertyType);
                prop.SetValue(entity, value);
            }

            batch.Add(entity);

            if (batch.Count >= batchSize)
            {
                await UpsertBatch(batch, keyProp);
                batch.Clear();
            }
        }

        if (batch.Count > 0)
        {
            await UpsertBatch(batch, keyProp);
        }
    }

    private async Task UpsertBatch<TEntity>(List<TEntity> batch, PropertyInfo keyProp)
        where TEntity : class
    {
        var set = _db.Set<TEntity>();

        var keyType = Nullable.GetUnderlyingType(keyProp.PropertyType) ?? keyProp.PropertyType;
        var typedList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(keyType))!;
        foreach (var val in batch.Select(b => keyProp.GetValue(b)))
            typedList.Add(val);

        var param = Expression.Parameter(typeof(TEntity), "e");
        var property = Expression.Property(param, keyProp);

        var containsMethod = typedList.GetType().GetMethod("Contains", new[] { keyType })!;
        var valuesExpr = Expression.Constant(typedList);
        var containsExpr = Expression.Call(valuesExpr, containsMethod, property);

        var lambda = Expression.Lambda<Func<TEntity, bool>>(containsExpr, param);

        var existing = await set.Where(lambda).ToListAsync();

        foreach (var entity in batch)
        {
            var keyValue = keyProp.GetValue(entity);
            var match = existing.FirstOrDefault(x => Equals(keyProp.GetValue(x), keyValue));

            if (match == null)
                set.Add(entity); 
            else
            {
                foreach (var p in typeof(TEntity).GetProperties())
                {
                    p.SetValue(match, p.GetValue(entity));
                }
            }
        }

        await _db.SaveChangesAsync();
    }


    private PropertyInfo? GetKeyProperty<TEntity>()
    {
        return typeof(TEntity)
            .GetProperties()
            .FirstOrDefault(p => p.GetCustomAttribute<CsvKeyAttribute>() != null);
    }

    private object? ConvertValue(string value, Type targetType)
    {
        var underlying = Nullable.GetUnderlyingType(targetType) ?? targetType;

        if (underlying.IsEnum)
            return Enum.Parse(underlying, value);

        if (underlying == typeof(DateOnly))
        {
            // Example: "2025-12-01"
            return DateOnly.Parse(value, CultureInfo.InvariantCulture);
        }

        if (underlying == typeof(TimeOnly))
        {
            // Example: "14:30:00"
            return TimeOnly.Parse(value, CultureInfo.InvariantCulture);
        }

        return Convert.ChangeType(value, underlying, CultureInfo.InvariantCulture);
    }
}
