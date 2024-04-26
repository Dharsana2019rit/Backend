using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restro.Models;

namespace Restro.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Phone);

            // Define the relationship with TableBooking
            builder.HasMany(c => c.TableBookings)
                   .WithOne(tb => tb.Customer)
                   .HasForeignKey(tb => tb.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade); // Add this line if you want cascading delete behavior
        }
    }
}
