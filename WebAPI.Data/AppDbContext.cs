using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Models;
using WebAPI.Data.TestData;

namespace WebAPI.Data;

public class AppDbContext: DbContext
{
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Purchase> Purchases { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        modelBuilder.Entity<Client>().HasData(ClientTestData.Clients);
        modelBuilder.Entity<Product>().HasData(ProductTestData.Products);
        modelBuilder.Entity<Purchase>().HasData(PurchaseTestData.Purchases);
        modelBuilder.Entity<ProductPurchase>().HasData(ProductPurchaseTestData.ProductPurchases);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }
}