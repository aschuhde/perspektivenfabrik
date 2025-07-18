using Application.Services;
using ImageMagick;

namespace Infrastructure.Services;

public class ImageService : IImageService
{
    public byte[] ResizeImageIfExceedsThreshold(byte[] imageData, uint thresholdWidth)
    {
        using var image = new MagickImage(imageData);
        
        if (image.Width <= thresholdWidth) return imageData;
        
        var ratio = (double)image.Height / image.Width;
        var newHeight = (uint)(thresholdWidth * ratio);
        image.Resize(thresholdWidth, newHeight);
        return image.ToByteArray();
    }
}