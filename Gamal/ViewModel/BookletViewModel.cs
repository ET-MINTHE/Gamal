using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class BookletViewModel
    {
        public string Course { get; set; }
        public string CourseCode { get; set; }  
        public int Year { get; set; }
        public bool Status { get; set; }
        public DateTime? ExamDate { get; set; }
        public int Mark { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string Sector { get; set; }

        public float EverageMark { get; set; }
        public float WeightedEverageMark { get; set; }      
    }
}
