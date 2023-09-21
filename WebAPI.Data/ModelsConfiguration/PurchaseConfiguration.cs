using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Data.Models;

namespace WebAPI.Data.ModelsConfiguration;

internal class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    /// <summary>
    ///     Configures the entity of type <typeparamref name="TEntity" />.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasKey(x => x.Number);

        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.TotalValue).IsRequired();

        builder
            .HasMany(x => x.Products)
            .WithOne(x => x.Purchase);
    }
}