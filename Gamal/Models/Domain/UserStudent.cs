using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class UserStudent
    {
        [Key]
        public string SerialNumber { get; set; }
        public string Email { get; set; }   
        public virtual ICollection<CourseUserStudent> CourseUserStudents { get; set; }
        public virtual ICollection<ExamEnrollment> ExamEnrollments { get; set; }
        public virtual ICollection<Booklet> Booklets { get; set; }
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }
        public string Profile { get; set; }
        public bool PartTime { get; set; }      
    }           
}   
                