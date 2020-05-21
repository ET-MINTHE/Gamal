using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class ProfileViewModel
    {   
        [Required(ErrorMessage ="La photo est obligatoire")]
        public IFormFile FileToUpload { get; set; }
        public string FilePath { get; set; }
    }
}
