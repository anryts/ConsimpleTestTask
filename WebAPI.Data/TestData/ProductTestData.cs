using WebAPI.Data.Models;

namespace WebAPI.Data.TestData;

public static class ProductTestData
{
    public static readonly List<Product> Products = new()
    {
        new Product
        {
            Article = Guid.NewGuid(),
            Name = "Product1",
            Category = Category.Electronics,
            Price = 29.99m,
        },
        new Product
        {
            Article = Guid.NewGuid(),
            Name = "Product2",
            Category = Category.Food,
            Price = 39.99m,

        },
        new Product
        {
            Article = Guid.NewGuid(),
            Name = "Product3",
            Category = Category.Clothes,
            Price = 49.99m,
        },
        new Product
        {
            Article = Guid.NewGuid(),
            Name = "Product4",
            Category = Category.Other,
            Price = 59.99m,
        }
    };
}