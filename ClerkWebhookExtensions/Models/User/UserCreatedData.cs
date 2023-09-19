using ClerkWebhookExtensions.Attributes;
using ClerkWebhookExtensions.Models.Common;
using Newtonsoft.Json;

namespace ClerkWebhookExtensions.Models.User
{
    [EventType("user.created")]
    public class UserCreatedData
    {
        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("email_addresses")]
        public List<ClerkEmailAddress> EmailAddresses { get; set; }

        [JsonProperty("external_accounts")]
        public List<object> ExternalAccounts { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("last_sign_in_at")]
        public long LastSignInAt { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("password_enabled")]
        public bool PasswordEnabled { get; set; }

        [JsonProperty("phone_numbers")]
        public List<object> PhoneNumbers { get; set; }

        [JsonProperty("primary_email_address_id")]
        public string PrimaryEmailAddressId { get; set; }

        [JsonProperty("primary_phone_number_id")]
        public object PrimaryPhoneNumberId { get; set; }

        [JsonProperty("primary_web3_wallet_id")]
        public object PrimaryWeb3WalletId { get; set; }

        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }

        [JsonProperty("two_factor_enabled")]
        public bool TwoFactorEnabled { get; set; }

        [JsonProperty("updated_at")]
        public long UpdatedAt { get; set; }

        [JsonProperty("username")]
        public object Username { get; set; }

        [JsonProperty("web3_wallets")]
        public List<WebWallet> WebWallets { get; set; }

    }
}
