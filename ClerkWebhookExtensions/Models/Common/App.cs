using Newtonsoft.Json;

namespace ClerkWebhookExtensions.Models.Common
{
    public class App
    {
        [JsonProperty("domain_name")] 
        public string DomainName { get; set; } = string.Empty;

        
        [JsonProperty("logo_image_url")] 
        public string LogoImageUrl { get; set; } = string.Empty;


        [JsonProperty("logo_url")]
        public object LogoUrl { get; set; } = null!;

        
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        
        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}
