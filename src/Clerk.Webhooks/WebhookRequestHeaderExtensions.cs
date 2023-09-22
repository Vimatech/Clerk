using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Clerk.Webhooks;

public static class WebhookRequestHeaderExtensions
{
   private static readonly string[] HeaderKeys = { "svix-id", "svix-timestamp", "svix-signature" };

   public static async Task VerifyWebhookHeaders(this HttpRequest request, string signingSecret)
   {
      var svix = new Svix.Webhook(signingSecret);
      
      request.EnableBuffering();
      
      var reader = new StreamReader(request.Body);

      var body = await reader.ReadToEndAsync();

      request.Body.Position = 0;

      var headers = new WebHeaderCollection();
      
      foreach (var key in HeaderKeys)
      {
         request.Headers.TryGetValue(key, out var value);
         
         headers.Add(key, value);
      }
      
      svix.Verify(body, headers);
   }
}