using Microservice_EF_MultiTenant.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Microservice_EF_MultiTenant.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TenantResolver
    {
        private readonly RequestDelegate _next;

        public TenantResolver(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ICurrentTenantService currentTenantService)
        {
            httpContext.Request.Headers.TryGetValue("tenant", out var tenantFromHeader);
            if (string.IsNullOrEmpty(tenantFromHeader) == false)
            {
                // set tenant id in scoped service
                await currentTenantService.SetTenant(tenantFromHeader);
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TenantResolverExtensions
    {
        public static IApplicationBuilder UseTenantResolver(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TenantResolver>();
        }
    }
}
