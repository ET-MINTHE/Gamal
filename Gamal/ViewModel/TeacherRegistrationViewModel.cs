using Gamal.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class TeacherRegistrationViewModel
    {
        [Required(ErrorMessage ="Le numero matricule de l'enseignant est obligatoire")]
        public string SerialNumber { get; set; }
        [Required(ErrorMessage ="Le prénom de l'enseignant est obligatoire")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Le nom de l'enseignant est obligatoire")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="L'adresse électronique est obligatoire")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Le département est obligatoire")]
        public string Department { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }   
        [Required(ErrorMessage ="Le bureau de l'enseignant est obligatoire")]
        public string Office { get; set; }
        [Required(ErrorMessage ="Le numero de téléphone est obligatoire")]
        public string PhoneNumber { get; set; } 
    }
}
