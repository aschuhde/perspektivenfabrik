using Application.Models;
using Application.Models.ServiceModels;
using Application.Services;
using ImageMagick;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class ImageService : IImageService
{
    private const uint MaxImageWidth = 1920;
    private const uint ThumbnailThreshold = 750;

    private bool IsVectorFormat(MagickFormat format)
    {
        return format is MagickFormat.Svg or MagickFormat.Svgz or MagickFormat.Eps or MagickFormat.Pdf or MagickFormat.Ai;
    }

    private (string, string) GetContentType(MagickImage image)
    {
        var formatInfo = MagickFormatInfo.Create(image.Format);

        return (formatInfo?.MimeType ?? "image/jpeg", formatInfo?.Format.ToString().ToLower() ?? ".jpg");
    }
    public ProcessedImageResult ProcessImage(byte[] imageData)
    {
        using var image = new MagickImage(imageData);
        var ratio = (double)image.Height / image.Width;
        var canResize = !IsVectorFormat(image.Format);
        var maxWidth = canResize ? MaxImageWidth : image.Width;
        var width = Math.Min(image.Width, maxWidth);
        var height = (uint)(width * ratio);
        uint thumbnailWidth = 500;
        uint thumbnailHeight = (uint)(thumbnailWidth * ratio);
        var withThumbnail = image.Width >= ThumbnailThreshold && canResize;
        var imageContentType = GetContentType(image);
        var result = new ProcessedImageResult()
        {
            LargeImage = new Image()
            {
                Width = (int)width,
                Height = (int)height,
                MimeType = imageContentType.Item1,
                FileExtension = imageContentType.Item2
            },
            ThumbnailImage = withThumbnail ? new Image()
            {
                Width = (int)thumbnailWidth,
                Height = (int)thumbnailHeight,
                MimeType = imageContentType.Item1,
                FileExtension = imageContentType.Item2
            } : null
        };
        
        if (image.Width > maxWidth)
        {
            image.Resize(width, height);
            result.LargeImage.Content = image.ToByteArray();
        }
        else
        {
            result.LargeImage.Content = imageData;
        }

        if (withThumbnail)
        {
            image.Resize(thumbnailWidth, thumbnailHeight);
            result.ThumbnailImage!.Content = image.ToByteArray();
        }
            
        return result;
    }
}