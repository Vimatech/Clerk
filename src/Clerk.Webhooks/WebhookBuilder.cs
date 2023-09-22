using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;

namespace Clerk.Webhooks;

internal sealed class WebhookBuilder : IWebhookBuilder
{
    private readonly IServiceCollection _services;

    private readonly WebhookEventProvider _provider;
    
    public WebhookBuilder(IServiceCollection services, WebhookEventProvider provider)
    {
        _services = services;
        _provider = provider;
    }

    /// <inheritdoc cref="AddHandler{TEvent,THandler}(string)"/>
    public void AddHandler<TEvent, THandler>(string @event) where TEvent : class
        where THandler : class, IWebhookHandler<TEvent>
    {
        InjectHandlerWithEvent<TEvent, THandler>(@event);
    }
    
    /// <inheritdoc cref="AddHandler{TEvent,THandler}(Expression{Func{WebhookEvent,string}})"/>
    public void AddHandler<TEvent, THandler>(Expression<Func<WebhookEvent, string>> expression) where TEvent : class
        where THandler : class, IWebhookHandler<TEvent>
    {
        var func = expression.Compile();

        var @event = func(new WebhookEvent());

        InjectHandlerWithEvent<TEvent, THandler>(@event);
    }

    public void AddSigningSecret(string signingSecret)
    {
        _provider.AddSigningSecret(signingSecret);
    }

    private void InjectHandlerWithEvent<TEvent, THandler>(string @event) where TEvent : class where THandler : class, IWebhookHandler<TEvent>
    {
        _services.AddTransient<IWebhookHandler<TEvent>, THandler>();
        
        _provider.RegisterEvent<TEvent>(@event);
    }
}