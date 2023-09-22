namespace Clerk.Webhooks;

/// <summary>
/// A interface to implement a webhook handler.
/// </summary>
/// <typeparam name="TEvent">The event type to handle</typeparam>
public interface IWebhookHandler<TEvent> where TEvent : class
{
    Task HandleAsync(Webhook<TEvent> webhook, CancellationToken cancellationToken);
}