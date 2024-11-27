namespace Reservation.Models
{
    public class Utilisateur
    {
        public Utilisateur()
        {
            Notifications = new List<Notifications>();
            Reservations = new List<Reservations>();
        }

        public int Id { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }

        public string? Nom { get; set; }
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }

        // Relation avec Notifications
        public List<Notifications> Notifications { get; set; }

        // Relation avec Reservations
        public List<Reservations> Reservations { get; set; }
    }
}
