namespace Gestion_de_Garage_Mécanique.Models
{
    public class Mecanicien
    {
        public int id { get; set; }
        public string nom { get; set; }

        public string prenom { get; set; }

        public string cin { get; set; }

        public int telephone { get; set; }

        public string domaine { get; set; }

        public string niveau { get; set; }
    }
}