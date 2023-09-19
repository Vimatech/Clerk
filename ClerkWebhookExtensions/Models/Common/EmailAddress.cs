using Newtonsoft.Json;

namespace ClerkWebhookExtensions.Models.Common
{
    public class ClerkEmailAddress
    {
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; } = string.Empty;

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("linked_to")]
        public List<object> LinkedTo { get; set; } = new List<object>();

        [JsonProperty("object")]
        public string Object { get; set; } = string.Empty;

        [JsonProperty("verification")]
        public Verification Verification { get; set; } = null!;
    }
}
