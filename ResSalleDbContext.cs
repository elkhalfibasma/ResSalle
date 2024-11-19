using Microsoft.EntityFrameworkCore;
using ResSalle.Configuration;
using ResSalle.Models;
namespace ResSalle
{
    public class ResSalleDbContext : DbContext
    {
      
        public DbSet<Equipements> Equipements { get;set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Salles> Salles { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public ResSalleDbContext(DbContextOptions<ResSalleDbContext>options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
         
            builder
               .ApplyConfiguration(new EquipementsConfiguration());
            builder
               .ApplyConfiguration(new RéservationConfiguration());
            builder
               .ApplyConfiguration(new SallesConfiguration());
            builder
               .ApplyConfiguration(new UtilisateurConfiguration());
            builder
               .ApplyConfiguration(new NotificationsConfiguration());

        }






    }
}
