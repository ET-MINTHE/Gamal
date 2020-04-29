using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class ExamEnrollment
    {
        public int ExamEnrollmentId { get; set; }
        
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public string SerialNumber { get; set; }
        public UserStudent UserStudent { get; set; }    
    }
}
