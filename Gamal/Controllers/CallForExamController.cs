using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gamal.Controllers
{
    public class CallForExamController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SerialNumber = "1245000000";
            return View();
        }
    }
}