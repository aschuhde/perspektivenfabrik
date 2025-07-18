namespace Application.Services;

public interface IImageService
{
    public byte[] ResizeImageIfExceedsThreshold(byte[] imageData, uint thresholdWidth);
}