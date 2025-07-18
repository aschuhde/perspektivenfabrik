using Application.Models.ServiceModels;

namespace Application.Services;

public interface IImageService
{
    public ProcessedImageResult ProcessImage(byte[] imageData);
}