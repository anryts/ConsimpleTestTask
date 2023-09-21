namespace WebAPI.Data.Models;

public class Product
{
    public Guid Article { get; set; }
    public string Name { get; set; } = null!;
    public Category Category { get; set; }
    public decimal Price { get; set; }

    public List<ProductPurchase> ProductPurchases { get; set; } = new();
}