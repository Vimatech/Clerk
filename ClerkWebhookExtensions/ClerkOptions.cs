namespace ClerkWebhookExtensions
{
    public class ClerkOptions
    {
        public UserOptions? User { get; set; }
    }

    public class UserOptions
    {
        public string? UserCreatedSigninSecret { get; set; }
        public string? UserDeletedSigninSecret { get; set; }
        public string? UserUpdatedSigninSecret { get; set; }
    }
}
