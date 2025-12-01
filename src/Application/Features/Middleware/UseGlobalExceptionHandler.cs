using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Middleware
{
    public sealed class UseGlobalExceptionHandler(RequestDelegate next, ILogger<UseGlobalExceptionHandler> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = ex switch
                {
                    ApplicationException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError


                };
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(

                    new ProblemDetails
                    {
                        Detail = ex.Message,
                        Title = "An error occurred while processing your request.",
                        Status = context.Response.StatusCode
                    });
            }
        }
    }
}
