using ClerkWebhookExtensions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace ClerkWebhookExtensions
{
    public sealed class ClerkMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ClerkMiddlewareOptions _options;

        public ClerkMiddleware(RequestDelegate next, ClerkMiddlewareOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Method is "GET")
            {
                await _next(httpContext);
            }

            if (httpContext.Request.Path.StartsWithSegments(_options.EndpointPrefix))
            {
                using var reader = new StreamReader(httpContext.Request.Body);
                var body = await reader.ReadToEndAsync();
                var payload = JsonConvert.DeserializeObject<Payload>(body);

                var factory = httpContext.RequestServices.GetRequiredService<ClerkMiddlewareFactory>();

                await factory.InvokeConsumer(payload, httpContext.RequestAborted);
            }
        }
    }
}