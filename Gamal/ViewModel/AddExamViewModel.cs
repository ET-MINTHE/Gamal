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
        [Required]
        public string Course { get; set; }
        [Required]  
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
