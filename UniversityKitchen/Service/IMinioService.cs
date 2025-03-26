namespace UniversityKitchen.Service;

public interface IMinioService
{
    Task<string> Uplaod(IFormFile file, string package);
    Task<string> GetImage(string imageName);
}