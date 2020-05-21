using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class BookletRepository : Repository<Booklet>, IBookletRepository
    {
        public BookletRepository(AppDbContext context)
           : base(context)
        {
        }

        public IEnumerable<Booklet> GetBookletByStudent(string studentSerialNumber, string searchTerm)
        {
            if (String.IsNullOrEmpty(searchTerm))
            {
                return AppContext.Booklets
                   .Include(b => b.UserStudent)
                   .Include(b => b.Course)
                   .ThenInclude(b => b.Department)
                   .Where(b => b.UserStudent.SerialNumber == studentSerialNumber).ToList();
            }
            else
            {
                return AppContext.Booklets
                   .Include(b => b.UserStudent)
                   .Include(b => b.Course)
                   .ThenInclude(b => b.Department)
                   .Where(b => b.UserStudent.SerialNumber == studentSerialNumber && b.Course.CourseName.Contains(searchTerm)).ToList();
            }
            
        }

        public async Task<bool> IsExamPassedByStudent(string serialNumber, string courseCode)
        {
            return (await AppContext.Booklets
                   .Include(b => b.UserStudent)
                   .Include(b => b.Course)
                   .CountAsync(b => b.UserStudent.SerialNumber == serialNumber && b.CourseCode == courseCode)) > 0 ? true:false;
        }

        public async Task<Booklet> GetStudentMarkByCourse(string serialNumber, string courseCode)
        {
            return await AppContext.Booklets
                   .Include(b => b.UserStudent)
                   .Include(b => b.Course)
                   .Where(b => b.UserStudent.SerialNumber == serialNumber && b.CourseCode == courseCode).FirstOrDefaultAsync();
        }

        public bool ExistStudentMarkForCourse(string studentSerialNumber, string teacherSerialNumber, string courseCode)
        {
            return AppContext.Booklets
                  .Where(b => b.StudentSerialNumber == studentSerialNumber && b.TeacherSerialNumber == teacherSerialNumber && b.CourseCode == courseCode).ToList().Count() != 0 ? true : false;
        }
        
        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
