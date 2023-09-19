using Newtonsoft.Json;
using Vimatech.Clerk.Webhooks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddClerkWebhooks(webhookBuilder =>
{
    webhookBuilder.AddWebhook<UserCreatedEvent, UserCreatedWebhook>(_ => "user.created");
    webhookBuilder.AddWebhook<UserDeletedEvent, UserDeletedWebhook>(@event => @event.UserDeleted);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseClerkWebhooks();

app.MapControllers();

app.Run();


public class UserCreatedEvent
{
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
    
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