namespace ClerkWebhookExtensions.Events
{
    public interface IClerkConsumer<T> : IClerkConsumer
        where T : class
    {
        Task HandleAsync(T message, CancellationToken cancellationToken);
    }

    public interface IClerkConsumer 
    {
    }
}
