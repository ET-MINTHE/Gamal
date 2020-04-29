using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context)
           : base(context)
        {
        }

        public IEnumerable<Course> GetCourseByDepartment(string department)
        {
            return AppContext.Courses
                   .Include(c => c.Department)
                   .Include(c => c.Faculty)
                   .Where(c => c.Department.DepartmentName == department).ToList();
        }
        public async Task<Course> GetCourseWithDepartment(string courseCode)
        {
            return await AppContext.Courses
                   .Include(c => c.Department)
                   .Where(c => c.CourseCode == courseCode).FirstOrDefaultAsync();
        }

        public IEnumerable<Course> GetCoursesByTeacher(string teacherSerialNumber)
        {
            return AppContext.Courses
                   .Include(c => c.UserTeacherCourses)
                   .Include(c => c.Teacher)
                   .Where(c => c.Teacher.SerialNumber == teacherSerialNumber).ToList();
        }


        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
