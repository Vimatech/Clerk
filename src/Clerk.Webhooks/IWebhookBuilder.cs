using System.Linq.Expressions;

namespace Clerk.Webhooks;

/// <summary>
/// Webhook builder interface for registering webhook handlers and related handler configurations.
/// See <see cref="WebhookBuilder"/> for the default implementation.
/// </summary>
public interface IWebhookBuilder
{
    /// <summary>
    /// Adds a webhook handler <see cref="IWebhookHandler{TEvent}"/> for the specified event type to the dependency
    /// injection container and appends the event type <see cref="TEvent"/> to
    /// the webhook provider <see cref="WebhookEventProvider"/>
    /// </summary>
    /// <param name="event">The name of the clerk webhook event to register a handler for</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    /// <typeparam name="THandler">The handler type</typeparam>
    void AddHandler<TEvent, THandler>(string @event)
        where TEvent : class where THandler : class, IWebhookHandler<TEvent>;

    /// <summary>
    /// Adds a webhook handler <see cref="IWebhookHandler{TEvent}"/> for the specified event type to the dependency
    /// injection container and appends the event type <see cref="TEvent"/> to
    /// the webhook provider <see cref="WebhookEventProvider"/>
    /// </summary>
    /// <param name="expression">An expression to select a preconfigured event to register a handler for</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    /// <typeparam name="THandler">The handler type</typeparam>
    void AddHandler<TEvent, THandler>(Expression<Func<WebhookEvent, string>> expression) where TEvent : class
        where THandler : class, IWebhookHandler<TEvent>;
    
    /// <summary>
    /// Configures the webhook middleware to use <a href="https://www.svix.com/">svix</a> for webhook verification of signing secret. 
    /// </summary>
    /// <param name="signingSecret">A string representing the signing secrets</param>
    void AddSigningSecret(string signingSecret);
}