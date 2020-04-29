using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(AppDbContext context)
           : base(context)
        {
        }

        public IEnumerable<Exam> GetExamByDepartment(string departmentId)
        {
            return AppContext.Exams
                   .Include(e => e.CourseExamSession)
                   .ThenInclude(c => c.Course)
                   .Where(e => e.CourseExamSession.Course.DepartmentCode == departmentId)
                   .ToList();
        }
        public IEnumerable<Exam> GetExamByTeacher(string teacherId)
        {
            return AppContext.Exams
                   .Include(e => e.CourseExamSession)
                   .ThenInclude(c => c.Course)
                   .Where(e => e.TeacherSerialNumber == teacherId)
                   .ToList();
        }
        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
