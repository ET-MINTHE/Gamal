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
        [Required]
        public string StudentSerialNumber { get; set; }
        [Required]
        public int Mark { get; set; }
        public IEnumerable<SelectListItem> AllMarks { get; set; }

        public string CourseName { get; set; }
        public IEnumerable<SelectListItem> AllCourses { get; set; } 
    }
}
    