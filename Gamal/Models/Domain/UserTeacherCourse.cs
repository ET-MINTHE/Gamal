using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Domain
{
    public class UserTeacherCourse
    {
        public string CourseCode { get; set; }
        public Course Course { get; set; }
        public string SerialNumber { get; set; }
        public UserTeacher UserTeacher { get; set; }
    }
}
