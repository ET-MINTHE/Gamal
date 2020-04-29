using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class CourseExamSessionRepository : Repository<CourseExamSession>, ICourseExamSessionRepository
    {
        public CourseExamSessionRepository(AppDbContext context)
           : base(context)
        {
        }

        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
