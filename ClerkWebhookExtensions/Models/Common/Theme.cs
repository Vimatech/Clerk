using Newtonsoft.Json;

namespace ClerkWebhookExtensions.Models.Common
{
    public class Theme
    {
        [JsonProperty("button_text_color")]
        public string ButtonTextColor { get; set; } = string.Empty;

     
        [JsonProperty("primary_color")]
        public string PrimaryColor { get; set; } = string.Empty;


        [JsonProperty("show_clerk_branding")]
        public bool ShowClerkBranding { get; set; }
    }
}
