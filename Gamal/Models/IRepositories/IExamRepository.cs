using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface IExamRepository : IRepository<Exam>
    {
        public IEnumerable<Exam> GetExamByDepartment(string departmentId);
        public IEnumerable<Exam> GetExamByTeacher(string teacherId);
    }
}
        