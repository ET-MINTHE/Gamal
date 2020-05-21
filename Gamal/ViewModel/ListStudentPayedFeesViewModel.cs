using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class ListStudentPayedFeesViewModel
    {
        public List<StudentPayedFeesViewModel> Model { get; set; }
        public string SearchTerm { get; set; }  
    }
}
