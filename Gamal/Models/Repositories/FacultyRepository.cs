using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class FacultyRepository : Repository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(AppDbContext context)
            : base(context)
        {   
        }

        public IEnumerable<string> GetFacultiesNames()
        {
            return AppContext.Faculties
                .Select(d => d.FacultyName).ToList();
        }
        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
