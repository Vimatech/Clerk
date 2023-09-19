using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Vimatech.Clerk.Webhooks;

internal sealed class ClerkWebhookMiddleware
{
    private readonly RequestDelegate _next;
        
    private readonly WebhookMiddlewareOptions _options;

    public ClerkWebhookMiddleware(RequestDelegate next, WebhookMiddlewareOptions options)
    {
        _next = next;
        _options = options;
    }
        
    public async Task InvokeAsync(HttpContext httpContext)
    {
        var method = httpContext.Request.Method;

        var path = httpContext.Request.Path.Value;
            
        if (!method.Equals(HttpMethods.Post) || !Regex.IsMatch(path, $"^/?{Regex.Escape(_options.RoutePrefix)}/?$"))
        {
            await _next(httpContext);
                
            return;
        }
            
            
        using var reader = new StreamReader(httpContext.Request.Body);
            
        var body = await reader.ReadToEndAsync();
            
        var payload = JsonConvert.DeserializeObject<Payload>(body);

            
            
        var provider = httpContext.RequestServices.GetRequiredService<WebhookProvider>();

        var eventType = provider.ResolveHandlerByEventName(payload.Type);

            

        dynamic @event = JsonConvert.DeserializeObject(payload.Data.ToString(), eventType);
            
        dynamic handler = httpContext.RequestServices.GetRequiredService(typeof(IWebhookHandler<>).MakeGenericType(eventType));
            
        await handler.HandleAsync(@event, httpContext.RequestAborted);
            
        httpContext.Response.StatusCode = StatusCodes.Status200OK;
    }
        
}