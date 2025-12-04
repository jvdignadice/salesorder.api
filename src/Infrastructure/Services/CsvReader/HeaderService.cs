using Domain.Common.CsvHeader;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.CsvReader
{
    public interface IHeaderService
    {
        string[] GetHeadersForType(Type type);
    }
    public class HeaderService : IHeaderService
    {
        private readonly Dictionary<Type, string[]> _headers;
        public HeaderService(IConfiguration configuration)
        {
            var headerSettings = new HeaderSettings();
            configuration.GetSection("Headers").Bind(headerSettings.Headers);

            _headers = new Dictionary<Type, string[]>();

            foreach (var kvp in headerSettings.Headers)
            {
                var type = Type.GetType(kvp.Key) ?? AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => t.Name == kvp.Key);

                if (type != null)
                    _headers[type] = kvp.Value;
            }
        }

        public string[] GetHeadersForType(Type type)
        {
            return _headers.TryGetValue(type, out var headers) ? headers : Array.Empty<string>();
        }
    }

}
