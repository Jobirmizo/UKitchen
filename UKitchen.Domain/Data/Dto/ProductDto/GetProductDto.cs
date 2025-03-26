namespace UKitchen.Domain.Data.Dto.ProductDto;

public class GetProductDto
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
    public List<string> Companies { get; set; }
    public string ProductCategory { get; set; }
}