using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class Department 
    { 
        [Key]
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public Faculty Faculty { get; set; }
        public string FacultyCode { get; set; } 
        public virtual ICollection<UserStudent> UserStudents { get; set; }
        public virtual ICollection<UserTeacher> UserTeachers { get; set; }
        public string CourseType { get; set; }
    }   
}       
