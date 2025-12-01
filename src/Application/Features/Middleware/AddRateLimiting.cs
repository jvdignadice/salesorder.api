using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Middleware
{
    public sealed class AddRateLimiting
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AddRateLimiting> _logger;
        private readonly int _maxRequests; 
        private readonly ConcurrentDictionary<string, ( int Count, DateTime lastReset)> _requests = new ConcurrentDictionary<string, (int Count , DateTime lastReset)>();
        private TimeSpan _timeWindow;
        public AddRateLimiting(RequestDelegate next, ILogger<AddRateLimiting> logger, int maxRequests, TimeSpan timeSpan)
        {
            _next = next;
            _logger = logger;
            _maxRequests = maxRequests;
            _timeWindow = timeSpan;
        }
        public async Task InvokeAsync(HttpContext context)
        {

            var clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            if (_requests.TryGetValue(clientIp, out var clientData))
            {
                if (DateTime.UtcNow - clientData.lastReset > _timeWindow)
                {
                    _requests.AddOrUpdate(clientIp, (1, DateTime.UtcNow), (key, existingVal) => (1, DateTime.UtcNow));
                }
                else if (clientData.Count >= _maxRequests)
                {
                    context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    await context.Response.WriteAsync("Too many requests. Please try again later.");
                    return;
                }
                else
                {
                    _requests.AddOrUpdate(clientIp, (clientData.Count + 1, clientData.lastReset), (key, existingVal) => (existingVal.Count + 1, existingVal.lastReset));
                }
            }
            else
            {
                _requests.TryAdd(clientIp, (1, DateTime.UtcNow));
            }

               await _next(context);
            
        }
    }
}
