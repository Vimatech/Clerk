using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Clerk.Webhooks;

public static class WebhookApplicationExtensions
{
    /// <summary>
    /// Adds clerk webhook middleware to the pipeline. It will listen for request made to endpoint '/clerk'
    /// from which it will invoke the registered webhook handlers.
    /// </summary>
    /// <param name="app">The application builder</param>
    /// <returns><see cref="IApplicationBuilder"/></returns>
    public static IApplicationBuilder UseClerkWebhooks(this IApplicationBuilder app)
    {
        return app.UseClerkWebhooks(options =>
        {
            options.RoutePrefix = "/clerk";
        });
    }
    
    /// <summary>
    /// Adds clerk webhook middleware to the pipeline. It will listen for request made to endpoint '/clerk' as default
    /// but can be configured to any other endpoint by configuring the <see cref="WebhookOptions.RoutePrefix"/> options.
    /// The middleware will invoke the registered webhook handlers.
    /// </summary>
    /// <param name="app">The application builder</param>
    /// <param name="action">An action to configure options</param>
    /// <returns><see cref="IApplicationBuilder"/></returns>
    /// <exception cref="ArgumentException">Exception occurs when route is not prefixed with a '/'</exception>
    public static IApplicationBuilder UseClerkWebhooks(this IApplicationBuilder app, Action<WebhookOptions> action)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var options = scope.ServiceProvider.GetRequiredService<IOptions<WebhookOptions>>().Value;

        if (!options.RoutePrefix.StartsWith("/"))
        {
            throw new ArgumentException("Endpoint prefix must start with a forward slash '/'.");
        }

        action.Invoke(options);

        app.UseMiddleware<WebhookMiddleware>(options);

        return app;
    }
}