using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Gamal.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Gamal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Index()
        {
            //string jsonData = @"[{  
            //                    'FirstName': 'Jignesh', 'LastName': 'Trivedi'}, {'FirstName': 'Elhadj Tahirou', 'LastName': 'Minthe'}]";

            //var myDetails = JsonConvert.DeserializeObject<List<MyDetail>>(jsonData);
            //_logger.LogInformation(string.Concat("Hi ", myDetails[1].FirstName, " " + myDetails[1].LastName));

            //_logger.LogInformation("Ciao Mondo!");
            //Console.WriteLine("Ciao Mondo!");
            //Console.WriteLine("");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult PrivateHome()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
