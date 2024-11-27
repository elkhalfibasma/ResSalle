using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Models;

namespace Reservation.Configuration
{
    public class NotificationsConfiguration : IEntityTypeConfiguration<Notifications>
    {
        public void Configure(EntityTypeBuilder<Notifications> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id)
                .UseIdentityColumn();

            builder.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(500);

            // Relation avec Utilisateur
            builder.HasOne(n => n.Utilisateur)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UtilisateurId);

            builder.ToTable("Notifications");
        }
    }
}
