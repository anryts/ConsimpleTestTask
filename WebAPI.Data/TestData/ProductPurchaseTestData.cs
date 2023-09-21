using WebAPI.Data.Models;

namespace WebAPI.Data.TestData;

public static class ProductPurchaseTestData
{
    public static readonly List<ProductPurchase> ProductPurchases = new()
    {
        new ProductPurchase
        {
            ProductId = ProductTestData.Products[0].Article,
            PurchaseId = PurchaseTestData.Purchases[0].Number

        },
        new ProductPurchase
        {
            ProductId = ProductTestData.Products[1].Article,
            PurchaseId = PurchaseTestData.Purchases[1].Number

        },
        new ProductPurchase
        {
            ProductId = ProductTestData.Products[2].Article,
            PurchaseId = PurchaseTestData.Purchases[2].Number

        },
        new ProductPurchase
        {
            ProductId = ProductTestData.Products[3].Article,
            PurchaseId = PurchaseTestData.Purchases[3].Number

        }
    };
}