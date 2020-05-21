using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class UniversityFeesRepository : Repository<UniversityFee>, IUniversityFeesRepository
    {
        public UniversityFeesRepository(AppDbContext context)
           : base(context)
        {
        }

        public bool ExistUniversityFeeWithYear(DateTime year)
        {
            var newYear = year.ToString("d/M/yyyy");
            var fees = AppContext.UniversityFees.ToList();

            foreach (var item in fees)
            {
                var oldYear = item.AcademicYear.ToString("d/M/yyyy");
                if (newYear.Equals(oldYear))
                {
                    return true;
                }
            }
            return false; 
        }
        public UniversityFee GetUniversityFeeByYear(DateTime year)
        {
            var newYear = year.ToString("yyyy");
            var fees = AppContext.UniversityFees.ToList();
            foreach (var item in fees)
            {
                var oldYear = item.AcademicYear.ToString("yyyy");
                if (newYear.Equals(oldYear))
                {
                    return item;
                }
            }
            return null;
        }
        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}   
