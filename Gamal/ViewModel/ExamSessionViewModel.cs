using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
    public class ExamSessionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Le nom de la session est obligatoire")]
        public string Name { get; set; }
        [Required(ErrorMessage ="La date de début est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime? Start { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="La date de fin de la session est obligatoire")]
        public DateTime? End { get; set; }
        public string Description { get; set; }
    }
}
