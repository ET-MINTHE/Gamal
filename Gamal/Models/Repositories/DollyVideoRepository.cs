using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class DollyVideoRepository : Repository<DollyVideo>, IDollyVideoRepository
    {
        public DollyVideoRepository(AppDbContext context)
           : base(context)
        {
        }

        public IEnumerable<DollyVideo> GetDollyVideoByTeacher(string teacherSerialNumber)
        {
            return AppContext.DollyVideos.Where(d => d.TeacherSerialNumber == teacherSerialNumber).ToList();
        }
        public IEnumerable<DollyVideo> GetDollyVideoByCourse(string courseId)
        {
            return AppContext.DollyVideos.Where(d => d.CourseCode == courseId).ToList();
        }
        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
