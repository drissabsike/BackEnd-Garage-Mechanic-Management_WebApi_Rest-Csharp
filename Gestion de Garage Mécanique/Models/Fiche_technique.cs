using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestion_de_Garage_Mécanique.Models
{
    public class Fiche_technique
    {
        public int id { get; set; }
        public string nom_mecanicien { get; set; }
        public string probleme_client { get; set; }
        public string service { get; set; }
        public DateTime date_creation { get; set; }
        public int duree_service_jrs { get; set; }
        public int montant_payer { get; set; }
        public string info_client { get; set; }

    }
}