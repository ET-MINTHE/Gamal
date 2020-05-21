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
        [Display(Name ="Adresse Electronique")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Date de Naissance")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Ville de Naissance")]
        public string CityOfBirth { get; set; }
        [Required]
        [Display(Name = "Nationalité")]
        public string Nationality { get; set; }
        [Required]
        [Display(Name = "Adresse")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Lycée")]
        public string HighSchool { get; set; }
        [Required]
        [Display(Name = "Option du Lycée")]
        public string HighSchoolOption { get; set; }
        [Required]
        [Display(Name = "Moyenne du Bac")]
        public int HighSchoolMark { get; set; }
        [Required]
        [Display(Name = "Année d'Optention du Bac")]
        public DateTime HighSchoolGraduateYear { get; set; }
        [Required]
        [Display(Name = "Année d'Inscription à l'Université")]
        public DateTime YearOfEnrolement { get; set; }
        [Required]
        [Display(Name = "Année")]
        public int CurrentYear { get; set; }
        [Required]
        [Display(Name = "Lieu de Résidence")]
        public string CityOfResidence { get; set; }
        [Required]
        [Display(Name = "Faculté")]
        public string Faculty { get; set; }
        [Required]
        [Display(Name = "Département")]
        public string Department { get; set; }
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }
        [Display(Name = "Nom")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Numéro de Téléphone")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Nom d'Ulitisateur")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Numero de Matricule")]
        public string SerialNumber { get; set; }
        [Display(Name = "Profile Etudiant")]
        public string StudentProfile { get; set; }
        [Display(Name = "Cours en temps partiel")]
        public string PartTime { get; set; }    
    }
}
