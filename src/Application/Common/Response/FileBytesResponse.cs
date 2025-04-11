namespace Application.Common.Response;

public class FileBytesResponse : BaseResponse
{
    public byte[]? Content { get; init; }
    public string? FileName { get; init; }
    public DateTimeOffset? LastModified { get; init; }
    public string? ContentType { get; init; }
    public bool IsInline { get; init; }
}
