using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClerkWebhookExtensions.Models.Common
{
    public class AppData
    {
        [JsonProperty("app")]
        public App App { get; set; } = null!;

        
        [JsonProperty("otp_code")]
        public string OtpCode { get; set; } = string.Empty;

        
        [JsonProperty("requested_at")] 
        public string RequestedAt { get; set; } = string.Empty;

       
        [JsonProperty("requested_by")] 
        public string RequestedBy { get; set; } = string.Empty;

        
        [JsonProperty("theme")]
        public Theme Theme { get; set; }

        
        [JsonProperty("user")]
        public User User { get; set; }
    }
}
