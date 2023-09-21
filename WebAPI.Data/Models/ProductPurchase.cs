namespace WebAPI.Data.Models;

public class ProductPurchase
{
    public Guid ProductId { get; set; }
    public Guid PurchaseId { get; set; }

    public Product Product { get; set; } = null!;
    public Purchase Purchase { get; set; } = null!;
}