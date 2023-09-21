using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

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

    public IWebhookBuilder<TEvent, THandler> AddWebhook<TEvent, THandler>(Expression<Func<WebhookEvent, string>> expression) 
        where THandler : class, IWebhookHandler<TEvent> 
        where TEvent : class, new()
    {
        var @func = expression.Compile();

        var @event = @func(new WebhookEvent());
            
        _services.AddTransient<IWebhookHandler<TEvent>, THandler>();
            
        _provider.RegisterHandler<TEvent>(@event);

        return new WebhookBuilder<TEvent, THandler>(_services, _provider);
    }
}

public class WebhookBuilder<TEvent, THandler> : IWebhookBuilder<TEvent, THandler>
    where THandler : class, IWebhookHandler<TEvent>
    where TEvent : class, new()
{
    private readonly IServiceCollection _services;
    private readonly WebhookProvider _provider;
    
    public WebhookBuilder(IServiceCollection services, WebhookProvider provider)
    {
        _services = services;
        _provider = provider;
    }

    public void AddValidation(WebhookValidationOptions<TEvent> options) 
    {
        _services.AddTransient(_ => options);
    }
}
