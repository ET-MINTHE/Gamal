using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class Booklet
    {
        public DateTime Date { get; set; }
        public int Mark { get; set; }
        public string CourseCode { get; set; }
        public Course Course { get; set; }
        public string StudentSerialNumber { get; set; }
        public UserStudent UserStudent { get; set; }
        public string TeacherSerialNumber { get; set; } 
    }   
}
