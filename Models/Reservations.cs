namespace Reservation.Models
{
    public class Reservations
    {
        public Reservations()
        {
            Equipements = new List<Equipements>();
        }

        public int Id { get; set; }

        // Relation avec Salle
        public int SalleId { get; set; }
        public Salle? Salle { get; set; }

        // Relation avec Utilisateur
        public int UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }

        // Relation Many-to-Many avec Equipements
        public List<Equipements> Equipements { get; set; }
    }
}
