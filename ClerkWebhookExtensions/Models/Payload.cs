using Newtonsoft.Json;

namespace ClerkWebhookExtensions.Models
{
    public class Payload
    {
        [JsonProperty("type")]
        public string Type { get; set; } = null!;

        [JsonProperty("data")]
        public object Data { get; set; } = null!;
    }
}
