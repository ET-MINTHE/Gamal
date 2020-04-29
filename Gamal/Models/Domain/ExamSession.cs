using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class ExamSession
    {
        [Key]
        public int ExamSessionId { get; set; }  
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; } 
        public virtual ICollection<CourseExamSession> CourseExamSessions { get; set; }
        public bool IsActive { get; set; }  
    }
}   
