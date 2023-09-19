using ClerkWebhookExtensions.Events;

namespace ClerkWebhookExtensions.Builder
{
    public interface IClerkBuilder
    {
        void AddConsumer<TImplementation, TPayload>()
            where TImplementation : class, IClerkConsumer<TPayload>
            where TPayload : class;
    }
}
