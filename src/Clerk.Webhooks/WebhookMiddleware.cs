using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Clerk.Webhooks;

public sealed class WebhookMiddleware
{
    private readonly RequestDelegate _next;
    
    private readonly WebhookOptions _options;

    public WebhookMiddleware(RequestDelegate next, WebhookOptions options)
    {
        _next = next;
        _options = options;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var method = httpContext.Request.Method;

        var path = httpContext.Request.Path;
        
        if (!method.Equals(HttpMethods.Post) || !Regex.IsMatch(path, $"^/?{Regex.Escape(_options.RoutePrefix)}/?$"))
        {
            await _next(httpContext);

            return;
        }
        
        var provider = httpContext.RequestServices.GetRequiredService<WebhookEventProvider>();
        
        
        using var reader = new StreamReader(httpContext.Request.Body);
        
        var body = await reader.ReadToEndAsync();
        
        
        var webhook = JsonConvert.DeserializeObject<Webhook<dynamic>>(body);

        if (webhook is null)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return;
        }
        
        var eventType = provider.GetEventType(webhook.Type);
        
        var @event = JsonConvert.DeserializeObject(webhook.Data.ToString(), typeof(Webhook<>).MakeGenericType(eventType));

        
        dynamic handler = httpContext.RequestServices.GetRequiredService(typeof(IWebhookHandler<>).MakeGenericType(eventType));

        
        await handler.HandleAsync(@event, httpContext.RequestAborted);

        httpContext.Response.StatusCode = StatusCodes.Status200OK;
    }
}