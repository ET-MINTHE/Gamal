using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamal.Models;
using Gamal.Models.Domain;
using Gamal.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gamal.Controllers
{
    public class ExamSessionController : Controller
    {
        [HttpGet]
        public IActionResult ExamSession()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddExamSession()
        {
            var model = new ExamSessionViewModel();
            ViewBag.Message = TempData["Message"]?.ToString();
            TempData["Message"] = "";
            model.Start = DateTime.Now;
            model.End = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        public IActionResult AddExamSession(ExamSessionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

                //if (true/*(model.Start < DateTime.Now) || (model.End < DateTime.Now) || (model.Start > model.End)*/)
                //{
                //    ViewBag.Error = $"La de début doit etre inférieur à la date de fin";
                //    return View(model);
                //}

                var examSession = new ExamSession();
                examSession.Start = model.Start ?? default(DateTime);
                examSession.End = model.End ?? default(DateTime);
                examSession.Name = model.Name;
                examSession.Description = model.Description;
                examSession.IsActive = true;

                unitOfWork.ExamSessions.Add(examSession);
                
                unitOfWork.Complete();

                TempData["Message"] = "La session a été enregistrer avec succès";
                return RedirectToAction("AddExamSession"); ;
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult RemoveExamSession()
        {
           return View();  
        }

        [HttpGet]
        public async Task<IActionResult> ExamSessionList()  
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var model = new List<ExamSessionViewModel>();
            var sessionList = unitOfWork.ExamSessions.GetAll().ToList();
			   foreach (var item in sessionList)
			   {
            model.Add(new ExamSessionViewModel { Description = item.Description, End = item.End, Start = item.Start, Name = item.Name });
			   }

            return View(model);
        }
   }
}