namespace Application.Common.Response;

public class FileInfoResponse : BaseResponse
{
    public required FileInfo FileInfo { get; init; }
    public required DateTimeOffset? LastModified { get; init; }
    public required string ContentType { get; init; }
}
