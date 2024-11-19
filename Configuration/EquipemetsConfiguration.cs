using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResSalle.Models;

namespace ResSalle.Configuration
{
    public class EquipementsConfiguration : IEntityTypeConfiguration<Equipements>
    {
        public void Configure(EntityTypeBuilder<Equipements> builder)
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
               .ToTable("Equipements");








        }
    }
}
