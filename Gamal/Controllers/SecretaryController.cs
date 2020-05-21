using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gamal.Controllers
{
    public class SecretaryController : Controller
    {
        public IActionResult Home()
        {
            ViewBag.Message = TempData["Message"]?.ToString();
            TempData["Message"] = "";
            return View();
        }
    }   
}   