using System.Linq.Expressions;

namespace Vimatech.Clerk.Webhooks;

public interface IWebhookBuilder
{
    void AddWebhook<TEvent, THandler>(Expression<Func<WebhookEvent, string>> expression) where THandler : class, IWebhookHandler<TEvent>
        where TEvent : class, new();
}