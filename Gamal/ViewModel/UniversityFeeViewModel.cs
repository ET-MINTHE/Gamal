using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class UniversityFeeViewModel
    {
        
        [Display(Name ="Année Accademique")]
        [Required(ErrorMessage ="L'année relative à la taxe est obligatoire")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime? AcademicYear { get; set; }
        [Required(ErrorMessage = "La date de début de payement de la taxe est obligatoire")]
        [Display(Name = "Date de début de payement")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "La date d'expiration de payement de la taxe est obligatoire")]
        [Display(Name = "Date limite de payement")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "La somme de la taxe est obligatoire")]
        [Display(Name = "Somme de la taxe")]
        public float? Ammount { get; set; }
    }
}
