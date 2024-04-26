using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restro.Models;

namespace Restro.Data.Configurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(mi => mi.MenuItemId);
            builder.Property(mi => mi.Name).IsRequired();
            builder.Property(mi => mi.Price).HasColumnType("decimal(18, 2)").IsRequired();
            builder.HasOne(mi => mi.Menu).WithMany(m => m.MenuItems).HasForeignKey(mi => mi.MenuId);
        }
    }
}

