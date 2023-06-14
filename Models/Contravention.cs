#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetFinal.Models
{
    public class Contravention
    {
         [Key]
        public int No_Fiche { get; set; }
        public int No_Dossier { get; set; }
        [ForeignKey("No_Dossier")]
        public Conducteur Conducteur {get;set;}
        public String Plaque_vehicule { get; set; }
        public String Couleur { get; set; }
        public String Marque { get; set; }
        public String Code_agent { get; set; }
        [ForeignKey("Code_agent")]
        public DCPR DCPR{get;set;}
        public String Adresse { get; set; }
        public String Article_violation { get; set; }
        public int Montant_a_payer { get; set; }
        public DateTime Date_contravention { get; set; }
    }
}