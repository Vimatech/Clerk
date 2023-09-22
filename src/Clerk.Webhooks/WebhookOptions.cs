namespace Clerk.Webhooks;

/// <summary>
/// An options class to configure the webhooks.
/// </summary>
public class WebhookOptions
{
    /// <summary>
    /// Configure the route prefix for the webhook endpoint.
    /// All webhooks will be sent to this endpoint.
    /// </summary>
    public string RoutePrefix { get; set; } = "/clerk";
}