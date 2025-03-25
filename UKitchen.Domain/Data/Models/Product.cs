using System;
using UniversityKitchen.Data.Enum;

namespace UniversityKitchen.Data.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double ActualPrice { get; set; }
    public double GivenPrice { get; set; }
    public double? Weight { get; set; }
    public double? Liter { get; set; }
    public bool IsExpired { get; set; } = false;
    public decimal Price { get; set; }
    public int CompanyId { get; set; }
    public DateTime DelveredAt { get; set; }
    public DateTime Exparetion { get; set; }
    public Company Company { get; set; }
    public ProductCategoryEnum ProductCategoryEnum { get; set; }
    
}