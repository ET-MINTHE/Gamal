using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gamal.Controllers
{
    public class PrivateHomeController : Controller
    {
        public IActionResult Home()
        {
            return View();  
        }
    }
}