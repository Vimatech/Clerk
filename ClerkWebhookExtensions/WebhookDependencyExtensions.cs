using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Vimatech.Clerk.Webhooks;

public static class ClerkWebhookExtensions
{
    public static IServiceCollection AddClerkWebhooks(this IServiceCollection services, Action<IWebhookBuilder> builder)
    {
        var provider = new WebhookProvider();
            
        var configurator = new WebhookBuilder(services, provider);

        builder.Invoke(configurator);
            
        services.AddSingleton(_ => provider);
            
        return services;
    }

    public static IApplicationBuilder UseClerkWebhooks(this IApplicationBuilder app)
    {
        return app.UseClerkWebhooks(_ =>
        {
            _.RoutePrefix = "/clerk";
        });
    }
        
    public static IApplicationBuilder UseClerkWebhooks(this IApplicationBuilder app, Action<WebhookMiddlewareOptions> action)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var options = scope.ServiceProvider.GetRequiredService<IOptions<WebhookMiddlewareOptions>>().Value;

        if (!options.RoutePrefix.StartsWith("/"))
        {
            throw new ArgumentException("Endpoint prefix must start with a forward slash '/'.");
        }

        action.Invoke(options);

        app.UseMiddleware<ClerkWebhookMiddleware>(options);

        return app;
    }
}