namespace WebAPI.Data.Models;

public class Purchase
{
    public Guid Number { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalValue { get; set; }
    public Guid ClientId { get; set; }

    public Client Client { get; set; }
    public List<ProductPurchase> Products { get; set; } = new();
}
