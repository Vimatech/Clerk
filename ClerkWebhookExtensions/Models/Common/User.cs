using Newtonsoft.Json;

namespace ClerkWebhookExtensions.Models.Common
{
    public class User
    {
        [JsonProperty("public_metadata")]
        public PublicMetadata PublicMetadata { get; set; }

        [JsonProperty("public_metadata_fallback")]
        public string PublicMetadataFallback { get; set; } = string.Empty;
    }
}
