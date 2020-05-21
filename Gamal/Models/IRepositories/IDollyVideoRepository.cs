using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface IDollyVideoRepository : IRepository<DollyVideo>
    {
        public IEnumerable<DollyVideo> GetDollyVideoByCourse(string courseId);
        public IEnumerable<DollyVideo> GetDollyVideoByTeacher(string teacherSerialNumber);
    }
}
        