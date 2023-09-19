# ClerkWebhookExtension

Clerk webhook extension is a library for c# to help you create a webhook extension for [clerk.com](https://clerk.com/).

## How to use

### install the package
Install the package from nuget:

```bash

dotnet add package ClerkWebhookExtension

```

Create a class that implements the consumer interface:

```csharp
import ClerkWebhookExtension.Models;
import ClerkWebhookExtension.Events;

public class MyConsumer : IClerkConsumer<UserCreatedData>
{
    public Task HandleAsync(UserCreatedData data, CancellationToken cancellationToken)
    {
        // Do something with the webhook event
    }
}
```

### Register the consumer

Register the consumer in the service collection:

```csharp
using ClerkWebhookExtension;
using ClerkWebhookExtension.Models;
using ClerkWebhookExtension.Events;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddClerk(builder => {
            builder.AddConsumer<UserCreatedData, MyConsumer>();
            // Add more consumers here
        });
    }
}
```

### Add the middleware

Add the middleware to the request pipeline:

```csharp
using ClerkWebhookExtension;

public class Startup
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseClerk(options => {
            options.Endpointprefix = "/webhook";
        });
    }
}
```