namespace Application.Common.Response;

public abstract class StringResponse(string content) : BaseResponse
{
    public string Content { get; } = content;
    public string ContentType { get; init; } = "text/plain";
}
