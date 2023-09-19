namespace Vimatech.Clerk.Webhooks;

internal class Payload
{
    public string Type { get; set; } = null!;
        
    public object Data { get; set; } = null!;
}