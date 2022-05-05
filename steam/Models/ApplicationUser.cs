using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace steam.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Nom complet")]
        public string FullName { get; set; }
    }
}