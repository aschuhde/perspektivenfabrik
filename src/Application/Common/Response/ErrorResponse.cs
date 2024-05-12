using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Services;
using Common;

namespace Application.Common.Response;

public sealed class ErrorResponseData
{
    public required Message Message { get; init; }
    public Guid ErrorId { get; init; } = Guid.NewGuid();
    public DateTimeOffset TimestampUtc { get; init; } = DateTime.UtcNow;
    public string Identifier { get; init; } = ErrorResponseIdentifier.Empty;
    [JsonIgnore]
    public Exception? RelatedException { get; init; }

    public ErrorResponse BuildErrorResponse(string requestMethod, string requestUrl)
    {
        return new ErrorResponse { Error = this, HttpVerb = requestMethod, RequestedUrl = requestUrl };
    }
}

public static class ErrorResponseIdentifier
{
    public const string Empty = "";
}
public sealed class ErrorResponse
{
    public required ErrorResponseData Error { get; init; }
    
    public required string? RequestedUrl { get; init; }
    public required string? HttpVerb { get; init; }
    
    public ErrorResponseException ToException()
    {
        return new ErrorResponseException(this.ToString(), Error.RelatedException);
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

public sealed class ErrorResponseException(string message, Exception? exception) : Exception(message, exception);
