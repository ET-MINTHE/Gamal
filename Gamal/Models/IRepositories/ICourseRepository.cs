using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        public IEnumerable<Course> GetCourseByDepartment(string department);
        public Task<Course> GetCourseWithDepartment(string courseCode);
        public IEnumerable<Course> GetCoursesByTeacher(string teacherSerialNumber);
        public IEnumerable<Course> SearchInDepartment(string department, string searchTerm);
        public IEnumerable<string> GetCourseNameByDepartment(string department, string searchTerm);
        public Course GetCourseByName(string courseName);
    }
}       
            