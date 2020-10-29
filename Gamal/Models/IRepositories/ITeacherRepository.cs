using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface ITeacherRepository : IRepository<UserTeacher>
    {
        public IEnumerable<UserTeacher> GetTeacherBySerialNumber(string searchTerm);
        public IEnumerable<Exam> GetExamByTeacher(string serialNumber);
    }
}  
    