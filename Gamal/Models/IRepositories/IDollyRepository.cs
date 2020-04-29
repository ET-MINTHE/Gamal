using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface IDollyRepository : IRepository<Dolly>
    {
        public IEnumerable<Dolly> GetDollyByCourse(string courseId);
        public IEnumerable<Dolly> GetDollyByTeacher(string teacherSerialNumber);    
    }
}
