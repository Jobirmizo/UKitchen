using UKitchen.Domain.Data.Dto.MealDto;

namespace UniversityKitchen.Features.Meal
{
    public interface IMealService
    {
        Task<List<GetMealDto>> GetAll();
        Task<GetMealDto> GetById(int id);
        Task<bool> Create(CreateMealDto dto);
        Task<bool> UploadMealFile(IFormFile file);
        Task<bool> Update();
        Task<bool> Delete(int id);
    }
}