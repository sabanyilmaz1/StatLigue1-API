using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetGL.Models
{
    public class Joueur
    {

        public int Id { get; set; }
        public int EquipeId { get; set; }

         [Display(Name = "Nom")]
        public string NomJoueur { get; set; }
         [Display(Name = "Prenom")]
        public string PrenomJoueur { get; set; }
         [Display(Name = "Age")]
        
        public int AgeJoueur { get; set; }
         [Display(Name = "Nationalité")]
        public string NationaliteJoueur{ get; set; }
         [Display(Name = "Taille (cm)")]
        public double TailleJoueur{get;set;}

        public Equipe Equipe { get; set; }

         [Display(Name = "Poste")]
        
        public string PosteJoueur { get; set; }
         [Display(Name = "Match")]
        public int MatchJouee {get;set;}
         [Display(Name = "Carton Jaune")]
        public int CartonJaune {get;set;}
         [Display(Name = "Carton Rouge")]
        public int CartonRouge {get;set;}
         [Display(Name = "But")]
        public int ButJoueur {get;set;}
         [Display(Name = "Passe décisive")]
        public int PasseDecisiveJoueur {get;set;}

        

    }
}