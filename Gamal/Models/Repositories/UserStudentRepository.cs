using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class UserStudentRepository : Repository<UserStudent>, IUserStudentRepository
    {
        public UserStudentRepository(AppDbContext context)
           : base(context)
        {
        }
        public IEnumerable<UserStudent> GetStudentByName(string searchTerm)
        {
            return AppContext.Students
                  .Where(s => s.Email.Contains(searchTerm)).ToList();
        }
        public IEnumerable<UserStudent> GetStudentBySerialNumber(string searchTerm)
        {
            return AppContext.Students
                  .Where(s => s.SerialNumber == searchTerm).ToList();
        }

        public bool ExistStudentWithSerialNumber(string serialNumber)
        {
            return AppContext.Students
                  .Where(s => s.SerialNumber == serialNumber).ToList().Count() != 0 ? true : false;
        }
        public AppDbContext AppContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
