using ClerkWebhookExtensions.Attributes;
using ClerkWebhookExtensions.Events;
using ClerkWebhookExtensions.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClerkWebhookExtensions.Builder
{
    public sealed class ClerkBuilder : IClerkBuilder
    {
        private readonly IServiceCollection _services;
        private readonly ClerkMiddlewareFactory _factory;

        public ClerkBuilder(IServiceCollection services, ClerkMiddlewareFactory factory)
        {
            _services = services;
            _factory = factory;
        }

        public void AddConsumer<TInterface, TImplementation, TPayload>()
            where TInterface : class, IClerkConsumer<TPayload>
            where TImplementation : class, TInterface
            where TPayload : class
        {
            _services.AddTransient<TInterface, TImplementation>();

            var consumer = _services.BuildServiceProvider().GetRequiredService<TInterface>();

            ConsumerNotFoundException.ThrowIfNull(consumer);

            var payloadType = typeof(TPayload);

            if (payloadType is null)
            {
                throw new NotSupportedException("Payload type not found");
            }

            var objectTypeAttribute = payloadType.GetCustomAttribute<EventTypeAttribute>();

            EventTypeNotFoundException.ThrowIfNull(objectTypeAttribute);

            var objectType = objectTypeAttribute.ObjectType;
            _factory.RegisterConsumer(objectType, consumer);
            _factory.RegisterType(objectType, payloadType);

        }
    }
}
