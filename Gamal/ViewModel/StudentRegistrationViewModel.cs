using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class StudentRegistrationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string CityOfBirth { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string HighSchool { get; set; }
        [Required]
        public string HighSchoolOption { get; set; }
        [Required]
        public int HighSchoolMark { get; set; }
        [Required]
        public DateTime HighSchoolGraduateYear { get; set; }
        [Required]
        public DateTime YearOfEnrolement { get; set; }
        [Required]
        public int CurrentYear { get; set; }
        [Required]
        public string CityOfResidence { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        public string Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }     
    }
}
