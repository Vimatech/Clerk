# Clerk Extensions

A collection of multiple clerk packages for .NET.

Clerk is adding support for [clerk.com](https://clerk.com/) to .NET.

Clerk.Webhooks is a simple extension for supporting webhooks from clerk.com.

## Clerk

### Installing Clerk

Clerk is available as a [NuGet package](https://www.nuget.org/packages/Clerk/) and can be installed as
```bash
Install-Package Clerk
```

or via the .NET Core command line interface:
```bash
dotnet add package Clerk
```

### Registering using Dependency Injection

## Clerk.Webhooks

### Installing Clerk.Webhooks

Clerk.Webhooks is available as a [NuGet package](https://www.nuget.org/packages/Clerk/) and can be installed as
```bash
Install-Package Clerk.Webhooks
```

or via the .NET Core command line interface:
```bash
dotnet add package Clerk.Webhooks
```

### Creating Webhook Events

Webhook events are simple data classes whose only purpose is to hold the data from the webhook.
The data is automatically deserialized from the webhook request.

Events are custom defined in order to enable better flexibility in case of data changes from the event catalog at clerk.com.

For example, if you would like to have a webhook event for when a user is created, you can create a class like this:

```csharp
public class UserCreated
{
    public string Id { get; set; }
    
    public string Username { get; set; }
    
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
    
    [JsonProperty("last_name")
    public string LastName { get; set; }
}
```

### Creating Webhook Handlers

```csharp
using Clerk.Webhooks;

public class UserCreatedWebhookHandler : IWebhookHandler<UserCreated>
{
    public Task HandleAsync(Webhook<UserCreated> webhook, CancellationToken cancellationToken)
    {
        // Do something with the webhook event
    }
}
```

The webhook handlers works with dependency injection, so you can inject any service you need into the handler by its constructor.

### Registering using Dependency Injection

```csharp
using Clerk.Webhooks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddClerkWebhooks(webhookBuilder => 
{
    // using predefined event names
    webhookBuilder.AddHandler<UserCreated, UserCreatedWebhookHandler>(@event => @event.User.Created);
    
    // or simply using string
    webhookBuilder.AddHandler<UserCreated, UserCreatedWebhookHandler>("user.created");
});
```

### Adding Validation

```csharp
using Clerk.Webhooks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddClerkWebhooks(webhookBuilder => 
{
    webhookBuilder.AddHandler<UserCreated, UserCreatedWebhookHandler>(@event => @event.User.Created);
    
    // Adding signing credentials for webhook validation using svix under the hood
    webhookBuilder.AddSigningSecret("signing-secret");
});
```

### Using the middleware

In order to enable request to the webhook endpoint, you need to add the middleware to the request pipeline.

By default, it uses the route prefix '/clerk', but you can change it to whatever you want.

Example using the default route prefix:

```csharp
using Clerk.Webhooks;

app = builder.build();

app.UseClerkWebhooks();
```

Example using a custom route prefix:

```csharp
using Clerk.Webhooks;

app = builder.build();

app.UseClerkWebhooks(options => 
{
    options.RoutePrefix = "/my-webhook-endpoint";
});
```
