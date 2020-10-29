using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using Gamal.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class ExamEnrollmentRepository : Repository<ExamEnrollment>, IExamEnrollmentRepository
    {
        public ExamEnrollmentRepository(AppDbContext context)
           : base(context)
        {
        }

        public bool IsExamEnrollmentReserved(string serialNumber, int examId)
        {
            return AppContext.ExamEnrollments.Where(ee => ee.SerialNumber == serialNumber && ee.ExamId == examId).Count() != 0 ? true : false;
        }

        public ExamEnrollment GetEnrollmentByExam(int examId)
        {
            return AppContext.ExamEnrollments.Where(ee => ee.ExamId == examId).FirstOrDefault();
        }

         public IEnumerable<Exam> GetStudentEnrollmentBySubject(string subject)
		   {
            return AppContext.Exams
                           .Include(e => e.ExamEnrollments).Where(x => x.Name == subject) .ToList();
         }

         
         public AppDbContext AppContext
         {
               get { return Context as AppDbContext; }
         }
    }
}
