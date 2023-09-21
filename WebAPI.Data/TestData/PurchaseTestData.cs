using WebAPI.Data.Models;

namespace WebAPI.Data.TestData;

public static class PurchaseTestData
{
    public static readonly List<Purchase> Purchases = new()
    {
        new Purchase
        {
            Number = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            TotalValue = 29.99m,
            ClientId = ClientTestData.Clients[0].Id,
        },
        new Purchase
        {
            Number = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            TotalValue = 39.99m,
            ClientId = ClientTestData.Clients[1].Id,
        },
        new Purchase
        {
            Number = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            TotalValue = 49.99m,
            ClientId = ClientTestData.Clients[2].Id,
        },
        new Purchase
        {
            Number = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            TotalValue = 59.99m,
            ClientId = ClientTestData.Clients[3].Id,
        }
    };
}