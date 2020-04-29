using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        public Department GetDepartmentAndFaculty(string departmentName);
        public IEnumerable<Department> GetDepartmentByFaculty(string facultyId);
        public IEnumerable<string> GetDepartmentByFacultyName(string facultyName);
    }
}   
    