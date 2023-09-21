using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Data.Models;

namespace WebAPI.Data.ModelsConfiguration;

internal class ProductPurchaseConfiguration : IEntityTypeConfiguration<ProductPurchase>
{
    /// <summary>
    ///     Configures the entity of type <typeparamref name="TEntity" />.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<ProductPurchase> builder)
    {
        builder.HasKey(x => new
        {
            x.ProductId, x.PurchaseId
        });
    }
}