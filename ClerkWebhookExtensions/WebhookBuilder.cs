using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;

namespace Vimatech.Clerk.Webhooks;

public class WebhookEvent
{
    public string UserCreated => "user.created";

    public string UserDeleted = "user.deleted";
    
    public string UserUpdated = "user.updated";
}


public sealed class WebhookBuilder : IWebhookBuilder
{
    private readonly IServiceCollection _services;

    private readonly WebhookProvider _provider;

    public WebhookBuilder(IServiceCollection services, WebhookProvider provider)
    {
        _services = services;
        _provider = provider;
    }

    public void AddWebhook<TEvent, THandler>(Expression<Func<WebhookEvent, string>> expression) where THandler : class, IWebhookHandler<TEvent> where TEvent : class, new()
    {
        var @func = expression.Compile();

        var @event = @func(new WebhookEvent());
            
        _services.AddTransient<IWebhookHandler<TEvent>, THandler>();
            
        _provider.RegisterHandler<TEvent>(@event);
    }
}