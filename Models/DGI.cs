#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetFinal.Models
{
    public class DGI
    
    {
        public int ID { get; set; }
        public int No_Fiche { get; set; }
        [ForeignKey("No_Fiche")]
        public Contravention contravention{get;set;}
        public int Montant { get; set; }
        public String Remarque { get; set; }
        public DateTime Date_paiement { get; set; }
    }
}