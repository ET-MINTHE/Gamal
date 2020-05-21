
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace Gamal.ViewModel
{
    public class BookletListViewModel
    {
        public IPagedList<BookletViewModel> BookletViewModels { get; set; }
        public string SearchTerm { get; set; }
        public string Filter { get; set; }  
    }   
}
