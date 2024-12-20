﻿namespace Reservation.Models
{
    public class Equipements
    {
        public Equipements()
        {
            Reservations = new List<Reservations>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }

        // Relation Many-to-Many avec Reservations
        public List<Reservations> Reservations { get; set; }
    }
}
