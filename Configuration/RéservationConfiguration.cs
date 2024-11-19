using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResSalle.Models;

namespace ResSalle.Configuration
{
    public class RéservationConfiguration : IEntityTypeConfiguration<Réservation>
    {
        public void Configure(EntityTypeBuilder<Réservation> builder)
        {
            builder
                 .HasKey(a => a.Id);
            builder
                .Property(a => a.Id)
                .UseIdentityColumn();
            builder
                .Property(c => c.Idsalle)
                .IsRequired();
            builder
               .ToTable("Réservation");







        }
    }
}
