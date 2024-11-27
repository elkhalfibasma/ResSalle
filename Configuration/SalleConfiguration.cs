using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Models;

namespace Reservation.Configuration
{
    public class SalleConfiguration : IEntityTypeConfiguration<Salle>
    {
        public void Configure(EntityTypeBuilder<Salle> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .UseIdentityColumn();

            builder.Property(s => s.Nom)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Capacite)
                .IsRequired();

            // Relation avec Reservations
            builder.HasMany(s => s.Reservations)
                .WithOne(r => r.Salle)
                .HasForeignKey(r => r.SalleId);

            builder.ToTable("Salles");
        }
    }
}
