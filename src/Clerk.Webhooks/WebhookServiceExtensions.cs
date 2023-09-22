using Microsoft.Extensions.DependencyInjection;

namespace Clerk.Webhooks;

public static class WebhookServiceExtensions
{
    /// <summary>
    /// A extension method to add Clerk Webhooks handlers and other options to the service collection
    /// which are to be used by the clerk webhook middleware.
    /// </summary>
    /// <param name="services">Service Collection</param>
    /// <param name="builder">A builder to configure clerk webhooks and handlers</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddClerkWebhooks(this IServiceCollection services, Action<IWebhookBuilder> builder)
    {
        var provider = new WebhookEventProvider();
        
        builder.Invoke(new WebhookBuilder(services, provider));
        
        services.AddSingleton(_ => provider);
        
        return services;
    }
}