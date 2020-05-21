using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class AddExamViewModel
    {
        [Required(ErrorMessage ="Le matière est obligatoire")]
        public string Course { get; set; }
        [Required(ErrorMessage ="La date de l'examen est obligatoire")]
        [DataType(DataType.Date)]
        [Display(Name ="Date de l'examen")]
        public DateTime Date { get; set; }
        [Required]
        public string Hour { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Classroom { get; set; } 
        public IEnumerable<SelectListItem> AllCourses { get; set; }

        public string Session { get; set; }
        public IEnumerable<SelectListItem> AllSessions { get; set; }    
    }
}
