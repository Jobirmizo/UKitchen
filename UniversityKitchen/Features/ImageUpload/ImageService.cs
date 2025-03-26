using Microsoft.EntityFrameworkCore;
using UniversityKitchen.Data.Context;

namespace UniversityKitchen.Features.ImageUpload;

public class ImageService(AppDbContext context) : IImageService
{
    private readonly AppDbContext _context = context;

    public Task<string> ImageUpload(IFormFile file)
    {
        throw new  NotImplementedException();
    }

    public Task<string> GetImage(string imageName)
    {
        throw new NotImplementedException();
    }
}