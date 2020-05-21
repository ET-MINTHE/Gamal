using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class UniversityFee
    {

        public DateTime AcademicYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
        public float Ammount { get; set; }  
    }
}   
            