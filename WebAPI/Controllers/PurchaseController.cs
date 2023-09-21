using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Controllers;

public static class PurchaseController
{
    public static void MapPurchaseEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/purchases");

        group.MapGet("get_last_purchases/{dayCount:int}", GetLastPurchases);
        group.MapGet("get_favorite_category/{clientId:guid}", GetPopularCategory);
    }

    /// <summary>
    /// Get last purchases of clients by last day count
    /// </summary>
    /// <param name="dayCount">Count of days</param>
    /// <param name="db"></param>
    /// <returns></returns>
    private static async Task<IResult> GetLastPurchases(int dayCount, AppDbContext db)
    {
        var purchases = await db.Purchases
            .Include(x => x.Client)
            .Where(x => x.Date >= DateTime.UtcNow.AddDays(-dayCount))
            .GroupBy(x => x.Client.Id)
            .Select(x => x.OrderByDescending(y => y.Date).FirstOrDefault())
            .ToListAsync();

        var purchasesDto = purchases.Select(x => new
        {
            //TODO: look here for null reference
            x!.Client.Id,
            x.Client.Initials,
            x.Date
        });

        return Results.Ok(purchasesDto);
    }

    /// <summary>
    /// Popular categories
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="db"></param>
    /// <returns>Returns a list of product categories that were purchased
    ///found client. For each category returns the quantity
    /// units purchased.</returns>;
    private static async Task<IResult> GetPopularCategory(Guid clientId, AppDbContext db)
    {
        var categories = await db.Purchases.Where(x => x.Client.Id == clientId)
            .SelectMany(x => x.Products.Select(productPurchase => productPurchase.Product.Category))
            .GroupBy(x => x)
            .Select(x => new
            {
                Category = x.Key.ToString(),
                Count = x.Count()
            })
            .ToListAsync();


        return Results.Ok(categories);
    }
}