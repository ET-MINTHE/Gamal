using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models
{
    public interface IUnitOfWork : IDisposable
    {
        public IFacultyRepository Faculties { get; }
        public IDepartmentRepository Departments { get; }
        public ICourseRepository Courses { get; }
        public IBookletRepository Booklets { get; }
        public ISecretaryRepository Secretaries { get; }
        public ITeacherRepository Teachers { get; }
        public IExamSessionRepository ExamSessions { get; }
        public IExamRepository Exams { get; set; }
        public ICourseExamSessionRepository CourseExamSessions { get; set; }

        public IExamEnrollmentRepository ExamEnrollments { get; set; }
        public IProfileRepository Profiles { get; set; }
        public IUniversityFeesRepository UniversityFees { get; set; }
        public IStudentFeeRepository StudentFees { get; set; }
        public IDollyVideoRepository DollyVideos { get; set; }
        int Complete(); 
    }
}
