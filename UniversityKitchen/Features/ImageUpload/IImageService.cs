namespace UniversityKitchen.Features.ImageUpload;

public interface IImageService
{
    Task<string> ImageUpload(IFormFile file);
    Task<string> GetImage(string imageName);
}