using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class StudentFee
    {
        public string StudentSerialNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime PayementDate { get; set; }
        public DateTime AccademicYear { get; set; }
        public float Ammount { get; set; }
        public string Email { get; set; }   
    }
}
    