
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage ="Le mot de passe actuel est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name ="Mot de passe actuel")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Le nouveau mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Nouveau mot de passe")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Le nouveau mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation mot de passe")]
        [Compare("NewPassword", ErrorMessage = "Les deux mots de passes ne coincident pas")]
        public string ConfirmPassword { get; set; }
    }
}
