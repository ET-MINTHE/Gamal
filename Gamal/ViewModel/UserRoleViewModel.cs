using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class UserRoleViewModel
    {
        [Required]
        [Display(Name ="Nom d'utilisateur")]
        public string UserName { get; set; }
        [Display(Name ="ajouter au role")]
        public bool IsSelected { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
        public IEnumerable<SelectListItem> AllRoles { get; set; }
    }
}
