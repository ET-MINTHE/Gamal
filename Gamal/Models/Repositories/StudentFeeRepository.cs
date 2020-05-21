using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class StudentFeeRepository : Repository<StudentFee>, IStudentFeeRepository
    {
        public StudentFeeRepository(AppDbContext context)
           : base(context)
        {
        }

        public IEnumerable<StudentFee> FindFeeByStudent(string serialNumber) {
            return AppContext.StudentFees
                .Where(s => s.StudentSerialNumber == serialNumber)
                .ToList();
        }

        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
