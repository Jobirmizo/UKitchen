using UKitchen.Domain.Data.Enum;

namespace UKitchen.Domain.Data.Dto.MealDto
{
    public class GetMealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double GivenPrice { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
        public MealCategoryEnum MealCategoryEnum { get; set; }
        public string? ImagePath { get; set; }
    }
}