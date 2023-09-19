using ClerkWebhookExtensions.Events;

namespace ClerkWebhookExtensions.Builder
{
    public interface IClerkBuilder
    {
        void AddConsumer<TInterface, TImplementation, TPayload>()
            where TInterface : class, IClerkConsumer<TPayload>
            where TImplementation : class, TInterface
            where TPayload : class;
    }
}
