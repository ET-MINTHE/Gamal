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
    }
}       
        