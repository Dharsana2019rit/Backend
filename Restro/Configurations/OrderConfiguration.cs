using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restro.Models;

namespace Restro.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.OrderDate)
                   .IsRequired();

            builder.Property(o => o.ItemName)
                   .IsRequired();

            builder.Property(o => o.Price)
                   .HasColumnType("decimal(18, 2)")
                   .IsRequired();

            builder.Property(o => o.Quantity)
                   .IsRequired();

        }
    }
}