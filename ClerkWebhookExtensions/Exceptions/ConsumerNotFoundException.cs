using ClerkWebhookExtensions.Events;

namespace ClerkWebhookExtensions.Exceptions
{
    public class ConsumerNotFoundException : Exception
    {
        public ConsumerNotFoundException()
            : base("Consumer not found.")
        {
        }

        public ConsumerNotFoundException(string message)
            : base(message)
        {
        }

        public ConsumerNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public static void ThrowIfNull(IClerkConsumer? consumer)
        {
            if (consumer == null)
            {
                throw new ConsumerNotFoundException(nameof(consumer));
            }
        }
    }
}
