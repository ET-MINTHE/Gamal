using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface IUniversityFeesRepository : IRepository<UniversityFee>
    {
        public bool ExistUniversityFeeWithYear(DateTime year);
        public UniversityFee GetUniversityFeeByYear(DateTime year);
    }
}
