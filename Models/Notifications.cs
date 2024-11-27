namespace Reservation.Models
{
    public class Notifications
    {
        public int Id { get; set; }
        public string Message { get; set; }

        // Relation avec Utilisateur
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
