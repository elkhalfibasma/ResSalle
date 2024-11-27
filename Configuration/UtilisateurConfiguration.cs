using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Models;

namespace Reservation.Configuration
{
    public class UtilisateurConfiguration : IEntityTypeConfiguration<Utilisateur>
    {
        public void Configure(EntityTypeBuilder<Utilisateur> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .UseIdentityColumn();

            builder.Property(u => u.Prenom)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Nom)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.Property(u => u.PasswordSalt)
                .IsRequired();

            builder.Property(u => u.IsAdmin)
                .IsRequired();

            // Relation avec Notifications
            builder.HasMany(u => u.Notifications)
                .WithOne(n => n.Utilisateur)
                .HasForeignKey(n => n.UtilisateurId);

            // Relation avec Reservations
            builder.HasMany(u => u.Reservations)
                .WithOne(r => r.Utilisateur)
                .HasForeignKey(r => r.UtilisateurId);

            builder.ToTable("Utilisateurs");
        }
    }
}
