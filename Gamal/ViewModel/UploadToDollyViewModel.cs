using Gamal.Models.Domain;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gamal.ViewModel
{
    public class UploadToDollyViewModel
    {
        [Required(ErrorMessage ="Le ficher est obligatoire")]
        public IFormFile PDFFileToUpload { get; set; }
        [Required(ErrorMessage = "Le ficher est obligatoire")]
        public IFormFile VideoFileToUpload { get; set; }
        public string TeacherSerialNumber { get; set; }
        public string FilePath { get; set; }
        public string CourseCode { get; set; }
        public string DepartmentCode { get; set; }
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Le nom du ficher Pdf est obligatoire")]
        public string PDFFileName { get; set; }

        [Required(ErrorMessage = "Le nom de la Vidéo est obligatoire")]
        public string VideoFileName { get; set; }
        public List<Dolly> Dollies { get; set; }
        public List<DollyVideo> DollyVideos { get; set; }   
    }   
}
