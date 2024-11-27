using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Models;

namespace Reservation.Configuration
{
    public class EquipementsConfiguration : IEntityTypeConfiguration<Equipements>
    {
        public void Configure(EntityTypeBuilder<Equipements> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn();

            builder.Property(e => e.Nom)
                .IsRequired()
                .HasMaxLength(100);

            // Many-to-Many relation with Reservations
            builder.HasMany(e => e.Reservations)
                .WithMany(r => r.Equipements)
                .UsingEntity(j => j.ToTable("ReservationEquipements"));

            builder.ToTable("Equipements");
        }
    }
}
