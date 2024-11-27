namespace Reservation.Models
{
    public class Salle
    {
        public Salle()
        {
            Reservations = new List<Reservations>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public int Capacite { get; set; }

        // Relation avec Reservations
        public List<Reservations> Reservations { get; set; }
    }
}
