using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class TeacherRepository : Repository<UserTeacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context)
           : base(context)
        {   
        }
        public IEnumerable<UserTeacher> GetTeacherBySerialNumber(string searchTerm)
        {
            return AppContext.Teachers
                  .Where(s => s.SerialNumber == searchTerm).ToList();
        }

        public IEnumerable<Exam> GetExamByTeacher(string serialNumber)
		  {
            return AppContext.Exams.Where(x => x.TeacherSerialNumber == serialNumber).ToList();
		  }

      public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
