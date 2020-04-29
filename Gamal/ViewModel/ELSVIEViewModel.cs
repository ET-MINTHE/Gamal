using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class ELSVIEViewModel
    {
        public int ExamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public string Classroom { get; set; }
        public string IsResered { get; set; }     
    }
}
