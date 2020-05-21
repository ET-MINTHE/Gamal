using Gamal.Models.IRepositories;
using Gamal.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Faculties = new FacultyRepository(_context);
            Departments = new DepartmentRepository(_context);
            Courses = new CourseRepository(_context);
            UserStudents = new UserStudentRepository(_context);
            Booklets = new BookletRepository(_context);
            Secretaries = new SecretaryRepository(_context);
            Teachers = new TeacherRepository(_context);
            ExamSessions = new ExamSessionRepository(_context);
            Exams = new ExamRepository(_context);
            CourseExamSessions = new CourseExamSessionRepository(_context);
            ExamEnrollments = new ExamEnrollmentRepository(_context);
            Dollies = new DollyRepository(_context);
            Profiles = new ProfileRepository(_context);
            UniversityFees = new UniversityFeesRepository(_context);
            StudentFees = new StudentFeeRepository(_context);
            DollyVideos = new DollyVideoRepository(_context);
        }
            
        public IFacultyRepository Faculties { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IUserStudentRepository UserStudents { get; private set; }
        public IBookletRepository Booklets { get; private set; }
        public ISecretaryRepository Secretaries { get; private set; }
        public ITeacherRepository Teachers { get; private set; }
        public IExamSessionRepository ExamSessions { get; private set; }
        public IExamRepository Exams { get; set; }
        public ICourseExamSessionRepository CourseExamSessions { get; set; }
        public IExamEnrollmentRepository ExamEnrollments { get; set; }
        public IDollyRepository Dollies { get; set; }
        public IProfileRepository Profiles { get; set; }
        public IUniversityFeesRepository UniversityFees { get; set; }
        public IStudentFeeRepository StudentFees { get; set; }
        public IDollyVideoRepository DollyVideos { get; set; }
        public int Complete()           
        {   
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
