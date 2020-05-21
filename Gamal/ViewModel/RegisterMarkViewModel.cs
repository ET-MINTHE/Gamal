using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class RegisterMarkViewModel
    {
        [Required(ErrorMessage ="Le nom de l'étudiant est obligatoire")]
        public string Student { get; set; }
        [Required(ErrorMessage ="La note est obligatoire")]
        public int? Mark { get; set; }
        public IEnumerable<SelectListItem> AllMarks { get; set; }
        [Required(ErrorMessage ="La matière est obligatoire")]
        public string CourseName { get; set; }
        public IEnumerable<SelectListItem> AllCourses { get; set; }
        public string SearchTerm { get; set; }
    }
}
    