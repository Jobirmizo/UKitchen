using UniversityKitchen.Data.Enum;

namespace UKitchen.Domain.Data.Dto.ExcelDto;

public class MealExcelDto
{
    public string Name { get; set; } 
    public double GivenPrice { get; set; }
    public int Quantity { get; set; }
    public bool Status { get; set; } = false;
    public int MealCategoryEnum{ get; set; }
    public string? ImagePath { get; set; }
}