using Gamal.Models.Domain;
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
    }
}   
    