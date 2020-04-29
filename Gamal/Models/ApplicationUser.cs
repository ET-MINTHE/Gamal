using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string SerialNumber { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public DateTime DateOfBirth { get; set; }
        public string CityOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string HighSchool { get; set; }
        public string HighSchoolOption { get; set; }
        public int HighSchoolMark { get; set; }
        public DateTime HighSchoolGraduateYear { get; set; }
        public DateTime YearOfEnrolement { get; set; }
        public int CurrentYear { get; set; }
        public string CityOfResidence { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Titre { get; set; }   
    }
}
