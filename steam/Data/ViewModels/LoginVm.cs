using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace steam.Data.ViewModels
{
    public class LoginVm
    {
        [Display(Name = "Adresse email")]
        [Required(ErrorMessage = "L'adresse email est requise")]
        public string EmailAddress { get; set; }

        [Display(Name = "Mot de passe")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}