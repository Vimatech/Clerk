using Newtonsoft.Json;

namespace ClerkWebhookExtensions.Models.Common
{
    public class Verification
    {

        [JsonProperty("attempts")]
        public int Attempts { get; set; }
        
        [JsonProperty("expire_at")]
        public long ExpireAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("strategy")]
        public string Strategy { get; set; }
    }
}
