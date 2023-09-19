using Newtonsoft.Json;

namespace ClerkWebhookExtensions.Models.Common
{
    public class WebWallet
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("verification")]
        public Verification Verification { get; set; }

        [JsonProperty("web3_wallet")]
        public string Wallet { get; set; }
    }
}
