using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClerkWebhookExtensions.Models.Common
{
    public class ClerkEmailAddress
    {
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("linked_to")]
        public List<object> LinkedTo { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("verification")]
        public Verification Verification { get; set; }
    }
}
