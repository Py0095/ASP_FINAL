#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjetFinal.Models
{
    public class Conducteur
    {
         [Key]
        public int No_Dossier { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Sexe { get; set; }
        public String Nif { get; set; }
    }
}