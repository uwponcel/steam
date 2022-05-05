using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace steam.Data.ViewModels
{
    public class RegisterVm
    {
        [Display(Name = "Nom complet")]
        [Required(ErrorMessage = "Le nom complet est requis")]
        public string FullName { get; set; }

        [Display(Name = "Adresse Email")]
        [Required(ErrorMessage = "L'adresse email est requise")]
        public string EmailAddress { get; set; }

        [Display(Name = "Mot de passe")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [Required(ErrorMessage = "La confirmation du mot de passe est requise")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mot de passes ne corresponde pas !")]
        public string ConfirmPassword { get; set; }
    }
}