using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class HighSchoolInfoViewModel
    {
        [Required(ErrorMessage = "Le lycée est un champ obligatoire")]
        public string HighSchool { get; set; }
        [Required(ErrorMessage ="L'option du lycée est un champ obligatoire")]
        public string HighSchoolOption { get; set; }
        [Required(ErrorMessage ="La moyenne du bac est un champ obligatoire")]
        public int HighSchoolMark { get; set; }
        [Required(ErrorMessage ="L'année d'optention du bac est un champ obligatoire")]
        [Display(Name ="Année d'optention du bac")]
        [DataType(DataType.Date)]
        public DateTime HighSchoolGraduateYear { get; set; }
        public IEnumerable<SelectListItem> AllHighSchools { get; set; }
        public IEnumerable<SelectListItem> AllHighSchoolOptions { get; set; }
        public IEnumerable<SelectListItem> AllHighSchoolMarks { get; set; } 
    }
}
