using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class StudentFacultyViewModel
    {
        [Required(ErrorMessage ="Le numero de matricule est un champ obligatoire")]
        public string SerialNumber { get; set; }
        [Required(ErrorMessage ="La faculté est un champ obligatoire")]  
        public string Faculty { get; set; }
        [Required(ErrorMessage ="Le département est un champ obligatoire")]
        public string Department { get; set; }
        [Required(ErrorMessage ="L'année d'inscription est un champ obligatoire")]
        [DataType(DataType.DateTime)]
        [Display(Name ="Année d'Inscription")]
        public DateTime YearOfEnrolement { get; set; }
        [Required(ErrorMessage ="Part Time est un champ obligatoire")]
        public string PartTime { get; set; }
        [Required(ErrorMessage ="Le profile étudiant est un champ obligatoire")]
        public string StudentProfile { get; set; }  
        [Required(ErrorMessage ="L'année courante est un champ obligatoire")]
        public int CurrentYear { get; set; }
        public IEnumerable<SelectListItem> AllCurrentYears { get; set; }
        public IEnumerable<SelectListItem> PartTimes { get; set; }
        public IEnumerable<SelectListItem> StudentProfiles { get; set; }    
        public IEnumerable<SelectListItem> AllDepartments { get; set; }
        public IEnumerable<SelectListItem> AllFaculties { get; set; }
    }
}
