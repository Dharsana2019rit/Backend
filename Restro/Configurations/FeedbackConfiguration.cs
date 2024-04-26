using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restro.Models;

namespace Restro.Data.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(f => f.FeedbackId);
            builder.Property(f => f.CustomerName).IsRequired();
            builder.Property(f => f.Email).IsRequired();
            builder.Property(f => f.Message).IsRequired();
            builder.Property(f => f.Date).IsRequired();
        }
    }
}
