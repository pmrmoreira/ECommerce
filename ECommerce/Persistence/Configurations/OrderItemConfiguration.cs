using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> b)
    {
        b.ToTable("OrderItems");
        b.HasKey(x => x.Id);
        b.Property(x => x.ProductId).IsRequired();
        b.Property(x => x.Quantity);
        
        b.OwnsOne(x => x.UnitPrice, p =>
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
