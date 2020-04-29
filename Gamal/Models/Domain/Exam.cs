using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class Exam
    {   
        [Key]
        public int ExamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseExamSessionId { get; set; }
        public CourseExamSession CourseExamSession { get; set; }
        public virtual ICollection<ExamEnrollment> ExamEnrollments { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public string Classroom { get; set; }
        public string TeacherSerialNumber { get; set; } 
    }       
}
