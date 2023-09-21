using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Data.Models;

namespace WebAPI.Data.ModelsConfiguration;

internal class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    /// <summary>
    ///     Configures the entity of type <typeparamref name="TEntity" />.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Initials)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasMany(x => x.Purchases)
            .WithOne(x => x.Client);
    }
}