namespace Clerk.Webhooks;

internal sealed class WebhookEventProvider
{
    private readonly Dictionary<string, Type> _events = new();
    
    private string? _signingSecret;
    
    public void RegisterEvent<TEvent>(string @event) where TEvent : class
    {
        _events.Add(@event, typeof(TEvent));
    }
    
    public Type GetEventType(string @event)
    {
        return _events[@event];
    }
    
    public void AddSigningSecret(string signingSecret)
    {
        _signingSecret = signingSecret;
    }
    
    public string? GetSigningSecret()
    {
        return _signingSecret;
    }
}