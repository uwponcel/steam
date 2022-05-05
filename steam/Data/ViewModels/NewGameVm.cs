using steam.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace steam.Models
{
    public class NewGameVm
    {
        public int Id { get; set; }

        [Display(Name = "Nom du jeux")]
        [Required(ErrorMessage = "Le nom du jeux est requis")]
        public string Name { get; set; }

        [Display(Name = "Description du jeux")]
        [Required(ErrorMessage = "La description du jeux est requise")]
        public string Description { get; set; }

        [Display(Name = "Prix en $")]
        [Required(ErrorMessage = "Le prix est requis")]
        public double Price { get; set; }

        [Display(Name = "URL du poster")]
        [Required(ErrorMessage = "L'URL du poster est requise")]
        public string ImageURL { get; set; }

        [Display(Name = "Date de sortie du jeux")]
        [Required(ErrorMessage = "LA date de sortie est requise")]
        public DateTime ReleaseDate { get; set; }


        [Display(Name = "Sélectionnez une catégorie")]
        [Required(ErrorMessage = "La catégorie est requise")]
        public GameCategory GameCategory { get; set; }

        //Relationships
        [Display(Name = "Sélectionnez les publishers")]
        [Required(ErrorMessage = "Les publishers du jeux sont requis")]
        public List<int> PublisherIds { get; set; }

        [Display(Name = "Sélectionnez un développeur")]
        [Required(ErrorMessage = "Le développeur du jeux est requis")]
        public int DevelopperId { get; set; }
    }
}