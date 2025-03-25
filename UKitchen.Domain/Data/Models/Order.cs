using UniversityKitchen.Data.Enum;

namespace UniversityKitchen.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MealId { get; set; }
        public int Quantity { get; set; }
        public OrderStatusEnum OrderStatusEnum { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public Meal Meal { get; set; }
    }
}