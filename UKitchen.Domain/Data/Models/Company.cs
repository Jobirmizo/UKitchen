using System.ComponentModel.DataAnnotations;

namespace UKitchen.Domain.Data.Models;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}