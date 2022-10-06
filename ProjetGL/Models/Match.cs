using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetGL.Models
{
    public class Match
    {

       public int Id { get; set; }
         [Display(Name = "Domicile")] 

        public Equipe EquipeD { get; set; }
          [Display(Name = "Extérieur")] 
        public Equipe EquipeE { get; set; }
        

        public int EquipeDId { get; set; }
        public int EquipeEId { get; set; }
          [Display(Name = "")] 
        public int ScoreD { get; set; }
          [Display(Name = "")] 
        public int ScoreE { get; set; }

        [Display(Name="Date"),DataType(DataType.Date)]
        public DateTime DateMatch {get;set;}

    }
}