using UniversityKitchen.Data.Models;

namespace UniversityKitchen.Features.Product.Dto;

public class CreateProduct
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double ActualPrice { get; set; }
    public double GivenPrice { get; set; }
    public double? Weight { get; set; }
    public double? Liter { get; set; }
    public bool IsExpired { get; set; } = false;
    public DateTime DelveredAt { get; set; }
    public DateTime Exparetion { get; set; }
    public int CompanyId { get; set; }
    public int ProductCategoryEnum { get; set; }
}