using System.Linq.Expressions;

namespace Vimatech.Clerk.Webhooks;

/// <summary>
/// Webhook builder interface for adding webhooks.
/// </summary>
public interface IWebhookBuilder
{
    /// <summary>
    /// Configures the webhook handler <see cref="IWebhookHandler{TEvent}"/> and adds the event type <see cref="TEvent"/> to the webhook provider <see cref="WebhookProvider"/>.
    /// </summary>
    /// <typeparam name="TEvent">The event type</typeparam>
    /// <typeparam name="THandler">The handler type <see cref="IWebhookHandler{TEvent}"/></typeparam>"/>
    /// <param name="expression">The expression to get the event name from <see cref="WebhookEvent"/>. To configure custom event names register by exprresion _ => "event.name"</param>
    /// <returns></returns>
    IWebhookBuilder<TEvent, THandler> AddWebhook<TEvent, THandler>(Expression<Func<WebhookEvent, string>> expression)
        where THandler : class, IWebhookHandler<TEvent>
        where TEvent : class, new();
}

/// <summary>
/// Webhook builder interface for adding webhook validation.
/// </summary>
/// <typeparam name="TEvent"><see cref="class"/></typeparam>
/// <typeparam name="THandler"><see cref="IWebhookHandler{TEvent}"/></typeparam>
public interface IWebhookBuilder<TEvent, THandler>
    where THandler : class, IWebhookHandler<TEvent>
    where TEvent : class, new()
{
    /// <summary>
    /// Add a validation options for <see cref="TEvent"/>. Adds the validation options <see cref="WebhookValidationOptions{TEvent}"/> as transient.
    /// </summary>
    /// <param name="options"></param>
    void AddValidation(WebhookValidationOptions<TEvent> options);
}