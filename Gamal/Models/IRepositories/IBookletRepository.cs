using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.IRepositories
{
    public interface IBookletRepository : IRepository<Booklet>
    {
        public IEnumerable<Booklet> GetBookletByStudent(string studentSerialNumber, string searchTerm);
        public Task<bool> IsExamPassedByStudent(string serialNumber, string courseCode);
        public Task<Booklet> GetStudentMarkByCourse(string serialNumber, string courseCode);
        public bool ExistStudentMarkForCourse(string studentSerialNumber, string teacherSerialNumber, string courseCode);
    }   
}
    