namespace UniversityKitchen.Features.UrlGenerator;

public interface IUrlGenerator
{
    string GenerateUrl(string action, string controller);
}