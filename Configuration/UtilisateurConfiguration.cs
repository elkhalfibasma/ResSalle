using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResSalle.Models;

namespace ResSalle.Configuration
{
    public class UtilisateurConfiguration : IEntityTypeConfiguration<Utilisateur>
    {
        public void Configure(EntityTypeBuilder<Utilisateur> builder)
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
               .Property(c => c.prénom)
               .IsRequired();
            builder
               .Property(c => c.email)
               .IsRequired();

            builder
                .ToTable("users");






        }
    }
}
