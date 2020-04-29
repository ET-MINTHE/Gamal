using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models
{
    public class CourseUserStudent
    {
        public string CourseCode { get; set; }
        public Course Course { get; set; }
        public string SerialNumber { get; set; }
        public UserStudent UserStudent { get; set; }
        public int Mark { get; set; }
        public DateTime ReportDate { get; set; }
        public string Description { get; set; }     
    }
}
