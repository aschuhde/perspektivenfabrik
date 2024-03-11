using System.Text.Json.Serialization;

namespace Common;

public class Message
{
    public string Content { get; init; }
    [JsonIgnore]
    public string? MessageId { get; init; }
    public Message(string content, string? id = null)
    {
        Content = content;
        MessageId = id;
    }
    
    public static implicit operator Message(string content) => new(content);

    public override string ToString() => Content;
}
