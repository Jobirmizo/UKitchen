using UniversityKitchen.Data.Enum;

namespace UKitchen.Domain.Data.Dto.MealDto;

public class CreateMealDto
{
    public string Name { get; set; }
    public double GivenPrice { get; set; }
    public int Quantity { get; set; }
    public bool Status { get; set; } = false;
    public MealCategoryEnum MealCategoryEnum { get; set; }
    public string? ImagePath { get; set; }
}

