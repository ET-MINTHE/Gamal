using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface IStudentFeeRepository : IRepository<StudentFee>
    {
        public IEnumerable<StudentFee> FindFeeByStudent(string serialNumber);
    }
}
    