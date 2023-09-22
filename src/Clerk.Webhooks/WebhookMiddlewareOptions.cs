namespace Clerk.Webhooks;

/// <summary>
/// An options class to configure the middleware for webhooks.
/// </summary>
public class WebhookMiddlewareOptions
{
    /// <summary>
    /// Configure the route prefix for the webhook endpoint.
    /// All webhooks will be sent to this endpoint.
    /// </summary>
    public string RoutePrefix { get; set; } = "/clerk";
}