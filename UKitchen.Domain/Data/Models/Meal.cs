using System.ComponentModel.DataAnnotations.Schema;
using UniversityKitchen.Data.Enum;

namespace UniversityKitchen.Data.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public double GivenPrice { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; } = false;
        public MealCategoryEnum MealCategoryEnum{ get; set; }
        public string? ImagePath { get; set; }
        
    }
}

