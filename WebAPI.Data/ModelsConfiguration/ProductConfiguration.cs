using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Data.Models;

namespace WebAPI.Data.ModelsConfiguration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    /// <summary>
    ///     Configures the entity of type <typeparamref name="TEntity" />.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Article);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Category)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.Price)
            .IsRequired();

        builder
            .HasMany(x => x.ProductPurchases)
            .WithOne(x => x.Product);

    }
}