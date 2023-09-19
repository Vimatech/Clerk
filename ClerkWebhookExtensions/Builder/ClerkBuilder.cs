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

        public void AddConsumer<TImplementation, TPayload>()
            where TImplementation : class, IClerkConsumer<TPayload>
            where TPayload : class
        {
            _services.AddTransient<IClerkConsumer<TPayload>, TImplementation>();

            var consumer = _services.BuildServiceProvider().GetRequiredService<IClerkConsumer<TPayload>>();

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
