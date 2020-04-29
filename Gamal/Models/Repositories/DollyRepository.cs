using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class DollyRepository : Repository<Dolly>, IDollyRepository
    {
        public DollyRepository(AppDbContext context)
           : base(context)
        {
        }

        public IEnumerable<Dolly> GetDollyByTeacher(string teacherSerialNumber)
        {
            return AppContext.Dollies.Where(d => d.TeacherSerialNumber == teacherSerialNumber).ToList();
        }
        public IEnumerable<Dolly> GetDollyByCourse(string courseId)
        {
            return AppContext.Dollies.Where(d => d.CourseCode == courseId).ToList();
        }
        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
