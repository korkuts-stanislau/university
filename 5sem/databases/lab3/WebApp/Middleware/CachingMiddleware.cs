using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace WebApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CachingMiddleware
    {
        private readonly RequestDelegate _next;

        public CachingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IMemoryCache cache, ComputerShopContext dbContext)
        {
            var services = dbContext.Services.Take(20).ToList();
            if (services != null)
            {
                cache.Set("services", services,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(2 * 7 + 240)));
            }
            var customers = dbContext.Customers.Take(20).ToList();
            if (customers != null)
            {
                cache.Set("customers", customers,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(2 * 7 + 240)));
            }
            var components = dbContext.Components.Take(20).ToList();
            if (components != null)
            {
                cache.Set("components", components,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(2 * 7 + 240)));
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CachingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCachingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CachingMiddleware>();
        }
    }
}
