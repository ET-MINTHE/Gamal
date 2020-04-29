using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class StudentContactViewModel
    {
        [Required(ErrorMessage = "L'adresse est un champ obligatoire")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Le numero de téléphone est obligatoire")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="La ville de résidence est obligatoire")]
        public string CityOfResidence { get; set; }
    }
}
