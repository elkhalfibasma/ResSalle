using Microsoft.EntityFrameworkCore;
using Reservation.Configuration;
using Reservation.Models;

namespace Reservation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Equipements> Equipements { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EquipementsConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationsConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationsConfiguration());
            modelBuilder.ApplyConfiguration(new SalleConfiguration());
            modelBuilder.ApplyConfiguration(new UtilisateurConfiguration());
        }
    }
}
