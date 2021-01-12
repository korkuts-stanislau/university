using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShopMvc.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ComputerShopMvc.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class InitializeDbMiddleware
    {
        private readonly RequestDelegate _next;
        public InitializeDbMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, ComputerShopContext dbContext)
        {
            DbInitializer initializer = new DbInitializer(500, 5000);
            initializer.Initialize(dbContext);

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class InitializeDbMiddlewareExtensions
    {
        public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<InitializeDbMiddleware>();
        }
    }
}
