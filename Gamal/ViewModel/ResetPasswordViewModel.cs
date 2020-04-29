using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class ResetPasswordViewModel
    {
        [Required]
        [Display(Name ="Adresse Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mot de Passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirmer le mot de Passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Les deux mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }  
    }   
}   
    