using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restro.Models;

namespace Restro.Data.Configurations
{
    public class TableBookingConfiguration : IEntityTypeConfiguration<TableBooking>
    {
        public void Configure(EntityTypeBuilder<TableBooking> builder)
        {
            builder.HasKey(tb => tb.TableBookingId);
            builder.Property(tb => tb.BookingDateTime).IsRequired();
            builder.Property(tb => tb.NumberOfGuests).IsRequired();
            builder.Property(tb => tb.TableNumber).IsRequired(); // Add TableNumber property configuration
            builder.Property(tb => tb.IsBooked).IsRequired(); // Add IsBooked property configuration
            builder.HasOne(tb => tb.Customer).WithMany(c => c!.TableBookings).HasForeignKey(tb => tb.CustomerId);
        }
    }
}