using ClerkWebhookExtensions.Attributes;
using ClerkWebhookExtensions.Models.Common;
using Newtonsoft.Json;

namespace ClerkWebhookExtensions.Models.Email
{
    [EventType("email.created")]
    public class EmailCreatedData
    {
        [JsonProperty("body")]
        public string Body { get; set; } = string.Empty;

        [JsonProperty("body_plain")] 
        public string BodyPlain { get; set; } = string.Empty;

        
        [JsonProperty("data")] 
        public AppData Data { get; set; } = null!;

        
        [JsonProperty("delivered_by_clerk")]
        public bool DeliveredByClerk { get; set; }

        
        [JsonProperty("email_address_id")] 
        public string EmailAddressId { get; set; } = string.Empty;

        
        [JsonProperty("from_email_name")] 
        public string FromEmailName { get; set; } = string.Empty;

        
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        
        [JsonProperty("slug")] 
        public string Slug { get; set; } = string.Empty;

        
        [JsonProperty("status")] 
        public string Status { get; set; } = string.Empty;

        
        [JsonProperty("subject")] 
        public string Subject { get; set; } = string.Empty;

        
        [JsonProperty("to_email_address")] 
        public string ToEmailAddress { get; set; } = string.Empty;

        
        [JsonProperty("user_id")] 
        public string UserId { get; set; } = string.Empty;
    }
}
