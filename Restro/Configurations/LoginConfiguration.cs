using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restro.Models;

namespace Restro.Data.Configurations
{
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(l => l.LoginId);
            builder.Property(l => l.EmailId).IsRequired();
            builder.Property(l => l.Password).IsRequired();
            builder.Property(l => l.Role)
       .IsRequired(); // Ensure Role is required


        }
    }
}