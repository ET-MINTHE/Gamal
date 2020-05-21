using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="L'adresse electronique est obligatoire")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Se rappeler")]
        public bool RememberMe { get; set; }
    }
}
    