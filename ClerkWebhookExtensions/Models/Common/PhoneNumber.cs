using Newtonsoft.Json;

namespace ClerkWebhookExtensions.Models.Common
{
    public class ClerkPhoneNumber
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("default_second_factor")]
        public bool DefaultSecondFactor { get; set; }
        
        [JsonProperty("linked_to")]
        public string[] LinkedTo { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("reserved_for_second_factor")]
        public bool ReservedForSecondFactor { get; set; }

        [JsonProperty("verification")]
        public Verification Verification { get; set; }
    }
}
