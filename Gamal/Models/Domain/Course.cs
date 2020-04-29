using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class Course
    {
        [Key]
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public Department Department { get; set; }
        public Faculty Faculty { get; set; }
        public UserTeacher Teacher { get; set; }
        public virtual ICollection<CourseUserStudent> CourseUserStudents { get; set; }
        public virtual ICollection<UserTeacherCourse> UserTeacherCourses { get; set; }
        public virtual ICollection<CourseExamSession> CourseExamSessions { get; set; }
        public virtual ICollection<Booklet> Booklets { get; set; }  
        public int Weight { get; set; }     
        public int Year { get; set; }       
        public string DepartmentCode { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public string Sector { get; set; }
       
    }   
}       
