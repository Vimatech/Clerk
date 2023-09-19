namespace Vimatech.Clerk.Webhooks;

public class WebhookProvider
{
    private readonly Dictionary<string, Type> _handlers = new();

    public void RegisterHandler<TEvent>(string @event) where TEvent : class, new()
    {
        _handlers.Add(@event, typeof(TEvent));
    }
    
    public Type ResolveHandlerByEventName(string @event)
    {
        return _handlers[@event];
    }
}