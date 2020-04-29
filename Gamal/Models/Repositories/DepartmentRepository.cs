using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context)
           : base(context)
        {
        }

        public Department GetDepartmentAndFaculty(string departmentName)
        {
            return AppContext.Departments
                .Include(d => d.Faculty)
                .Where(d => d.DepartmentName == departmentName).FirstOrDefault();
        }

        public IEnumerable<Department> GetDepartmentByFaculty(string facultyCode)
        {
            return AppContext.Departments
                .Where(d => d.FacultyCode == facultyCode).ToList();
        }

        public IEnumerable<string> GetDepartmentByFacultyName(string facultyName)
        {
            return AppContext.Departments
                .Include(d => d.Faculty)
                .Where(d => d.Faculty.FacultyName == facultyName)
                .Select(d => d.DepartmentName)
                .ToList();
        }

        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}   
