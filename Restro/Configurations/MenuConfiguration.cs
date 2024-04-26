using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restro.Models;

namespace Restro.Data.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.MenuId);
            builder.Property(m => m.Category).IsRequired();
            builder.HasMany(m => m.MenuItems).WithOne(mi => mi.Menu).HasForeignKey(mi => mi.MenuId);
        }
    }
}