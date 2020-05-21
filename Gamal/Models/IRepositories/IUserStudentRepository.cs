using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface IUserStudentRepository : IRepository<UserStudent>
    {
        public IEnumerable<UserStudent> GetStudentByName(string searchTerm);
        public IEnumerable<UserStudent> GetStudentBySerialNumber(string searchTerm);
        public bool ExistStudentWithSerialNumber(string serialNumber);
    }
}
    