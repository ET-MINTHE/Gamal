using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class Faculty
    {
        public string FacultyName { get; set; }
        [Key]
        public string FacultyCode { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }   
}
