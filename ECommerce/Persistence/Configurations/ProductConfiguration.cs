using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> b)
    {
        b.ToTable("Products");
        b.HasKey(x => x.Id);

        b.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        b.Property(x => x.StockQuantity)
            .IsRequired();

        // Money — Value Object mapeado como Owned Entity
        b.OwnsOne(x => x.Price, p =>
        {
            p.Property(m => m.Amount)
                .HasColumnName("Price")
                .HasColumnType("numeric(18,2)");

            p.Property(m => m.Currency)
                .HasColumnName("Currency")
                .HasMaxLength(3);
        });
    }
}