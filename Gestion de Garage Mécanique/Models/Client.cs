using System;

namespace Gestion_de_Garage_Mécanique.Models
{
    public class Client
    {

        public int id { get; set; }
        public string nom { get; set; }

        public string prenom { get; set; }

        public string cin { get; set; }

        public int telephone { get; set; }

        public string adresse { get; set; }

        public int cp { get; set; }

        public string ville { get; set; }

        public string vehicule { get; set; }

        public DateTime date_create { get; set; }

        public string info_client { get; set; }

    }
}