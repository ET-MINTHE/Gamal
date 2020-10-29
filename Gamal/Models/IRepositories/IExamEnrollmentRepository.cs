using Gamal.Models.Domain;
using Gamal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface IExamEnrollmentRepository : IRepository<ExamEnrollment>
    {
        public bool IsExamEnrollmentReserved(string studentSerialNumber, int examId);
        public ExamEnrollment GetEnrollmentByExam(int examId);
       public IEnumerable<Exam> GetStudentEnrollmentBySubject(string subject);
	}
}   
    