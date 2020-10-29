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
        [Required(ErrorMessage = "L'heure de l'examen est obligatoire")]
        public string Hour { get; set; }
        [Required(ErrorMessage ="La description de l'examen est obligatoire")]
        public string Description { get; set; }
        [Required(ErrorMessage = "La salle de l'examen est obligatoire")]
        public string Classroom { get; set; } 
        public IEnumerable<SelectListItem> AllCourses { get; set; }
        [Required(ErrorMessage = "La salle session de l'examen est obligatoire")]
        public string Session { get; set; }
        public IEnumerable<SelectListItem> AllSessions { get; set; }    
    }
}
