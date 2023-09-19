namespace ClerkWebhookExtensions.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class EventTypeAttribute : Attribute
    {
        public string ObjectType { get; set; }

        public EventTypeAttribute(string objectType)
        {
            ObjectType = objectType;
        }
    }
}
