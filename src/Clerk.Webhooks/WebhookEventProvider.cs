namespace Clerk.Webhooks;

internal sealed class WebhookEventProvider
{
    private readonly Dictionary<string, Type> _events = new();
    
    public void RegisterEvent<TEvent>(string @event) where TEvent : class
    {
        _events.Add(@event, typeof(TEvent));
    }
    
    public Type GetEventType(string @event)
    {
        return _events[@event];
    }
}