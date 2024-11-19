using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResSalle.Models;

namespace ResSalle.Configuration
{
    public class NotificationsConfiguration : IEntityTypeConfiguration<Notifications>
    {
        public void Configure(EntityTypeBuilder<Notifications> builder)
        {
            builder
                 .HasKey(a => a.Id);
            builder
                .Property(a => a.Id)
                .UseIdentityColumn();
            builder
                .Property(c => c.message)
                .IsRequired();

            builder
               .ToTable("Notifications");





        }
    }
}
