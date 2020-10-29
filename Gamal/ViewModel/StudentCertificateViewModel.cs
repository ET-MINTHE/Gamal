using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class StudentCertificateViewModel
    {
        [Required(ErrorMessage ="le nom ou le matricule est obligatoire")]
        public string Student { get; set; } 
    }
}
