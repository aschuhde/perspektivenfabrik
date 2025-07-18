namespace Application.Models.ServiceModels;

public class ProcessedImageResult
{
    public required Image LargeImage { get; set; }
    public required Image? ThumbnailImage { get; set; }
}

public class Image
{
    public required int Width { get; set; }
    public required int Height { get; set; }
    public required string MimeType { get; set; }
    public required string FileExtension { get; set; }
    public byte[] Content { get; set; } = [];
}