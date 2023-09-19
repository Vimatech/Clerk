namespace Vimatech.Clerk.Webhooks;

public interface IWebhookHandler<TEvent> where TEvent : class
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken);
}