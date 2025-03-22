using UKitchen.Domain.Data.Dto.ExcelDto;

namespace UniversityKitchen.Features.ImportFile;

public interface IExcelService
{
    Task<List<MealExcelDto>> ReadExcelFileAsync(IFormFile file);
}