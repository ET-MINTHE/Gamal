using Gamal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Gamal.ViewModel
{
    public class StudentDollyViewModel
    {
        public IPagedList<Course> ViewModel { get; set; }
        public string SearchTerm { get; set; }
    }   
}
    