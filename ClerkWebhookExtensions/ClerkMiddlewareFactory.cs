using ClerkWebhookExtensions.Events;
using ClerkWebhookExtensions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace ClerkWebhookExtensions
{
    public sealed class ClerkMiddlewareFactory
    {
        private Dictionary<string, object> Consumers { get; set; }
        private Dictionary<string, Type> MessageTypes { get; set; }
        
        public ClerkMiddlewareFactory()
        {
            Consumers = new Dictionary<string, object>();
            MessageTypes = new Dictionary<string, Type>();
        }

        public void RegisterConsumer<T>(string objectType, IClerkConsumer<T> consumer)
            where T : class
        {
            Consumers.Add(objectType, consumer);
        }

        public void RegisterType(string objectType, Type type)
        {
            MessageTypes.Add(objectType, type);
        }

        public Task InvokeConsumer(Payload payload, CancellationToken cancellationToken)
        {
            if (MessageTypes.TryGetValue(payload.Type, out var type))
            {
                dynamic data = JsonConvert.DeserializeObject(payload.Data.ToString(), type);

                if (data is null)
                {
                    throw new HttpRequestException();
                }

                if (Consumers.TryGetValue(payload.Type, out dynamic consumer) && data is not null)
                {
                    return (Task) consumer.HandleAsync(data, cancellationToken);
                }
            }

            return Task.CompletedTask;
        }
    }
}
