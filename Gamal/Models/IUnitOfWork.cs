using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models
{
    interface IUnitOfWork : IDisposable
    {
        IFacultyRepository Faculties { get; }
        IDepartmentRepository Departments { get; }
        ICourseRepository Courses { get; }
        IBookletRepository Booklets { get; }
        ISecretaryRepository Secretaries { get; }
        ITeacherRepository Teachers { get; }
        IExamSessionRepository ExamSessions { get; }
        public IExamRepository Exams { get; set; }
        public ICourseExamSessionRepository CourseExamSessions { get; set; }

        public IExamEnrollmentRepository ExamEnrollments { get; set; }  
        int Complete();
    }
}
