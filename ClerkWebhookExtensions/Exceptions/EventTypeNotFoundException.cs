using ClerkWebhookExtensions.Attributes;

namespace ClerkWebhookExtensions.Exceptions
{
    internal class EventTypeNotFoundException : Exception
    {
        public EventTypeNotFoundException()
            : base("event type not found.")
        {
        }

        public EventTypeNotFoundException(string message)
            : base(message)
        {
        }

        public EventTypeNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public static void ThrowIfNull(EventTypeAttribute? eventType)
        {
            if (eventType is null) 
            {
                throw new EventTypeNotFoundException(nameof(eventType));
            }
        }
    }
}
