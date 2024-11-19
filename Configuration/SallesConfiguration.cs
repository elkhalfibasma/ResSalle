using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResSalle.Models;

namespace ResSalle.Configuration
{
    public class SallesConfiguration : IEntityTypeConfiguration<Salles>
    {
        public void Configure(EntityTypeBuilder<Salles> builder)
        {
            builder
                 .HasKey(a => a.Id);
            builder
                .Property(a => a.Id)
                .UseIdentityColumn();
            builder
                .Property(c => c.nom)
                .IsRequired();
            builder
                .Property(c => c.Capacité)
                .IsRequired();
            builder
               .ToTable("Salles");








        }
    }
}
