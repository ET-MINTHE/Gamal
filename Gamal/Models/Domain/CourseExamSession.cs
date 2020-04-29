using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class CourseExamSession
    {
        [Key]
        public int CourseExamSessionId { get; set; }    
        public string CourseCode { get; set; }
        public Course Course { get; set; }
        public int ExamSessionId { get; set; }  
        public ExamSession ExamSession { get; set; }
        public ICollection<Exam> Exams { get; set; }    
    }
}
