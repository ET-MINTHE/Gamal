using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class StudentEnrollmentListViewModel
    {
        public StudentEnrollmentViewModel CurrentEnrollment { get; set; }
        public List<StudentEnrollmentViewModel> EnrollmentList { get; set; }
    }   
}   
