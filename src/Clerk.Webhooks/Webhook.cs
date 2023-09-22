namespace Clerk.Webhooks;

/// <summary>
/// Base implementation of a webhook.
/// </summary>
/// <typeparam name="TEvent">The event to be handled - payload registered as data property</typeparam>
public class Webhook<TEvent> where TEvent : class
{
    public string Object { get; set; } = null!;
    
    public string Type { get; set; } = null!;
    
    public TEvent Data { get; set; } = null!;
}