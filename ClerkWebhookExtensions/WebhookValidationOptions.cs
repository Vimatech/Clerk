namespace Vimatech.Clerk.Webhooks
{
    public class WebhookValidationOptions<TEvent> where TEvent : class
    {
        public string SigninSecret { get; set; } = null!;
        public bool ThrowOnValidationError { get; set; } = true;

        public WebhookValidationOptions(string signinSecret)
        {
            SigninSecret = signinSecret;
        }
    }
}