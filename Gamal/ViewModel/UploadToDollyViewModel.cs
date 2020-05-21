using Gamal.Models.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class UploadToDollyViewModel
    {
        [Required]
        public IFormFile FileToUpload { get; set; }
        public string TeacherSerialNumber { get; set; }
        public string FilePath { get; set; }
        public string CourseCode { get; set; }
        public string DepartmentCode { get; set; }
        public string CourseName { get; set; }
        [Required]
        public string FileName { get; set; }

        public List<Dolly> Dollies { get; set; }
        public List<DollyVideo> DollyVideos { get; set; }   
    }   
}
