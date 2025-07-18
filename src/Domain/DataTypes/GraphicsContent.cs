namespace Domain.DataTypes;

public sealed class GraphicsContent
{
    public required byte[] Content { get; init; }
    public required int Width { get; set; }
    public required int Height { get; set; }
    public required string MimeType { get; set; }
    public required string FileExtension { get; set; }
}