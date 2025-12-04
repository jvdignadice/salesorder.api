using Domain.Entities.Pizza;
using Domain.Entities.SalesOrder;

namespace Infrastructure.Services.CsvReader
{
    public class CsvTypeDetector
    {
        public Type? DetectCsvType(string[] csvHeader, IHeaderService headerService)
        {
            var knownTypes = new[] { typeof(OrderDetails), typeof(Orders), typeof(PizzaType), typeof(Pizza) };

            foreach (var type in knownTypes)
            {
                var configuredHeaders = headerService.GetHeadersForType(type);

                if (csvHeader.Length == configuredHeaders.Length &&
                    csvHeader.All(h => configuredHeaders.Contains(h)))
                {
                    return type;
                }
            }

            return null;
        }
    }
}
