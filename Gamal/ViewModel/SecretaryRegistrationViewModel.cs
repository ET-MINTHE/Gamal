using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
	public class SecretaryRegistrationViewModel
	{
      [Required(ErrorMessage = "Le numero matricule du secrétaire est obligatoire")]
      public string SerialNumber { get; set; }
      [Required(ErrorMessage = "Le prénom du secrétaire est obligatoire")]
      public string FirstName { get; set; }
      [Required(ErrorMessage = "Le nom du secrétaire est obligatoire")]
      public string LastName { get; set; }
      [Required(ErrorMessage = "L'adresse du secrétaire électronique est obligatoire")]
      public string Email { get; set; }
      public string Office { get; set; }
      [Required(ErrorMessage = "Le numero de téléphone du secrétaire est obligatoire")]
      public string PhoneNumber { get; set; }
   }
}
