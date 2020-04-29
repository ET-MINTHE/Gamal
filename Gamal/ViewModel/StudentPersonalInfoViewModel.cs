using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class StudentPersonalInfoViewModel
    {
        [Required(ErrorMessage ="L'Adresse électronique est un champ obligatoire")]
        public string Email { get; set; }
        [Required(ErrorMessage ="La date de naissance est un champ obligatoire")]
        [Display(Name ="Date de Naissance")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage ="La ville de naissance est un champ obligatoire")]
        public string CityOfBirth { get; set; }
        [Required(ErrorMessage ="La nationalité est un champ obligatoire")]
        public string Nationality { get; set; }
        [Required(ErrorMessage ="Le prénom est un champ obligatoire")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Le nom est un champ obligatoire")]
        public string LastName { get; set; }
    }
}
