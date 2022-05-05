﻿using steam.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace steam.Models
{
    public class Publisher:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Photo de profile")]
        [Required(ErrorMessage = "La photo de profile est requise")]
        public string ProfilePictureURL { get; set; }
        
        [Display(Name = "Nom du Studio")]
        [Required(ErrorMessage = "Le nom du studio est requis")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Le nom du studio doit être entre 3 et 50 caractères.")]
        public string StudioName { get; set; }

        [Display(Name = "Biographie")]
        [Required(ErrorMessage = "La biographie est requise")]
        public string Bio { get; set; }

        ///Relationships
        public List<Game_Publisher> Games_Publishers { get; set; }
    }
}
