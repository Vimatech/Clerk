using Newtonsoft.Json;
using Vimatech.Clerk.Webhooks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddClerkWebhooks(webhookBuilder =>
{
    webhookBuilder.AddWebhook<UserCreatedEvent, UserCreatedWebhook>(@event => @event.UserCreated)
        .AddValidation(new("whsec_LbagXYSOomN3puMwVySFmgXVCxgjIJ6"));

    webhookBuilder.AddWebhook<UserDeletedEvent, UserDeletedWebhook>(@event => @event.UserDeleted)
        .AddValidation(new("whsec_LbagXYSOomN3puMwVySFmgXVCxgjIJ6C"));
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseClerkWebhooks();

app.Run();


public class UserCreatedEvent
{
    [JsonProperty("first_name")]
    public string  FirstName { get; set; }
    
    [JsonProperty("last_name")]
    public string LastName { get; set; }
    
    [JsonProperty("profile_image_url")]
    public string ProfileImageUrl { get; set; }
}

public class UserDeletedEvent
{
    public bool Deleted { get; set; }

    public string Id { get; set; } = null!;

    public string Object { get; set; } = null!;
}

public class UserCreatedWebhook : IWebhookHandler<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedWebhook> _logger;

    public UserCreatedWebhook(ILogger<UserCreatedWebhook> logger)
    {
        _logger = logger;
    }
    
    public Task HandleAsync(UserCreatedEvent @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation(JsonConvert.SerializeObject(@event));

        return Task.CompletedTask;
    }
}

public class UserDeletedWebhook : IWebhookHandler<UserDeletedEvent>
{
    public Task HandleAsync(UserDeletedEvent @event, CancellationToken cancellationToken)
    {
        Console.WriteLine(JsonConvert.SerializeObject(@event));

        return Task.CompletedTask;
    }
}