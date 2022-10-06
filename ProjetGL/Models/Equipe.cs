using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetGL.Models
{
    public class Equipe
    {

       public int Id { get; set; }

        [Display(Name = "Equipe")]
        public string NomEquipe { get; set; }
        [Display(Name = " ")]
        public string AcronymeClub { get; set; }


        [Display(Name = "Entraineur")]
        public string NomEntraineur { get; set; }

        [Display(Name = "Points")]  
        public int NombrePoints { get; set; }
        [Display(Name = "V")]
        public int NombreVictoire { get; set; }
        [Display(Name = "D")]
        public int NombreDefaite { get; set; }
        [Display(Name = "N")]
        public int NombreNul { get; set; }

        [Display(Name = "DB")]
        public int DifferencedeBut { get; set; }

        [Display(Name = "Classement")]
        
        public int ClassementEquipe { get; set; }
        [Display(Name = "Effectif")]
        
        public ICollection<Joueur> LesJoueurs { get; set; }

       

        

    
        


        

    }
}

