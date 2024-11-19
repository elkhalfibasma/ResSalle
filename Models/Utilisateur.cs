namespace ResSalle.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string nom { get; set; }
        public string prénom { get; set; }
        public string email { get; set; }
        public bool isadmin { get; set; }

    }
}
