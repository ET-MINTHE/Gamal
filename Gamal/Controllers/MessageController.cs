using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gamal.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Message(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}