# Clek Extensions

Clerk webhook extension is a library for c# to help you create a webhook extension for [clerk.com](https://clerk.com/).

## How to use

### install the package
Install the package from nuget:

```bash

dotnet add package Vimatech.Clerk.Webhooks --version [![Latest Release](https://img.shields.io/github/v/release/Vimatech/Vimatech.Clerk)](https://github.com/Vimatech/Vimatech.Clerk/releases)

```

Create a class that implements the webhook interface:

```csharp
using Vimatech.Clerk.Webhook

public class MyWebhookEvent : IWebhookEvent<UserCreated>
{
    public Task HandleAsync(UserCreated data, CancellationToken cancellationToken)
    {
        // Do something with the webhook event
    }
}
```

### Register the webhook and validation

Register the webhook and validation in the service collection:

```csharp
using Vimatech.Clerk.Webhook

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddClerk(webhookBuilder => {
    webhookBuilder.AddWebhook<UserCreated, MyWebhookEvent>()
        .AddValidation(new WebhookValidationOptions<UserCreated {
            SigninSecret = "signin-secret"
            });

    // Add more webhooks and validations here
});
 
```

Your signin secret can be found in the clerk dashboard under webhooks -> endpoints -> signin secret.

Notice that not using validation would be a security risk.

### Add the middleware

Add the middleware to the request pipeline:

```csharp
using Vimatech.Clerk.Webhook

app = WebApplication.Create(args);

app.UseClerk(options => {
    options.Endpointprefix = "/endpoint";
});

```

The endpoint prefix is the prefix that will be used for the webhook endpoint. The default is "/clerk".
