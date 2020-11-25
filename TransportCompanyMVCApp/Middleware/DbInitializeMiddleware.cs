using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using TransportCompanyMVCApp.Data;

namespace TransportCompanyMVCApp.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DbInitializeMiddleware
    {
        private readonly RequestDelegate _next;

        public DbInitializeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, TransportCompanyContext db)
        {
            if (!(httpContext.Session.Keys.Contains("starting")))
            {
                InitializerDb.Initialize(db);
                httpContext.Session.SetString("starting", "Yes");
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DbInitializeMiddlewareExtensions
    {
        public static IApplicationBuilder UseDbInitializeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbInitializeMiddleware>();
        }
    }
}
