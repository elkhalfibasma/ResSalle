using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Models;

namespace Reservation.Configuration
{
    public class ReservationsConfiguration : IEntityTypeConfiguration<Reservations>
    {
        public void Configure(EntityTypeBuilder<Reservations> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .UseIdentityColumn();

            // Relation avec Salle
            builder.HasOne(r => r.Salle)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.SalleId);

            // Relation avec Utilisateur
            builder.HasOne(r => r.Utilisateur)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UtilisateurId);

            // Many-to-Many relation with Equipements
            builder.HasMany(r => r.Equipements)
                .WithMany(e => e.Reservations)
                .UsingEntity(j => j.ToTable("ReservationEquipements"));

            builder.ToTable("Reservations");
        }
    }
}
