using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class UserTeacher
    {
        [Key]
        public string SerialNumber { get; set; }
        public string Office { get; set; }  
        public virtual ICollection<UserTeacherCourse> UserTeacherCourses { get; set; }
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }
    }
}
