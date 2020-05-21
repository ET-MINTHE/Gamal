using Gamal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Gamal.ViewModel
{
    public class SearchStudentViewModel
    {
        public IPagedList<ApplicationUser> Students { get; set; }
        public string SearchTerm { get; set; }
        public StudentViewModel Model { get; set; }
        public float Ammount { get; set; }  
    }
}
