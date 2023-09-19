using ClerkWebhookExtensions.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClerkWebhookExtensions
{
    public static class ClerkWebhookExtensions
    {
        public static IServiceCollection AddClerk(this IServiceCollection services, Action<IClerkBuilder> builder)
        {

            var factory = new ClerkMiddlewareFactory();
            var configurator = new ClerkBuilder(services, factory);

            builder.Invoke(configurator);

            services.AddSingleton(factory);

            return services;
        }

        public static IApplicationBuilder UseClerk(this IApplicationBuilder app, Action<ClerkMiddlewareOptions> action)
        {
            using var scope = app.ApplicationServices.CreateScope();

            ClerkMiddlewareOptions options = scope.ServiceProvider.GetRequiredService<IOptions<ClerkMiddlewareOptions>>().Value;

            if (!options.EndpointPrefix.StartsWith("/"))
            {
                throw new ArgumentException("Endpoint prefix must start with a forward slash '/'.");
            }

            action.Invoke(options);

            app.UseMiddleware<ClerkMiddleware>(options);

            return app;
        }
    }
}