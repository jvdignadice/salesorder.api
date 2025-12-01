using Application.Features.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Extensions
{
    public static class CustomRateLimiting
    {
        public static IApplicationBuilder AddCustomRateLimiting(this IApplicationBuilder builder, int maxRequests, TimeSpan timeSpan)
        {
            return builder.UseMiddleware<AddRateLimiting>(maxRequests, timeSpan);
        }
    }
}
