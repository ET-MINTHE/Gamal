using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface IFacultyRepository : IRepository<Faculty>
    {
        public IEnumerable<string> GetFacultiesNames();
    }
}
