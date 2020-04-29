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
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");

            return View();
        }

        [HttpGet]
        public IActionResult AddExamSession()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");

            var model = new ExamSessionViewModel();
            ViewBag.Message = TempData["Message"]?.ToString();
            TempData["Message"] = "";
            return View(model);
        }
        [HttpPost]
        public IActionResult AddExamSession(ExamSessionViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
                ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
                ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");

                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

                var examSession = new ExamSession();
                examSession.Start = model.Start;
                examSession.End = model.End;
                examSession.Name = model.Name;
                examSession.Description = model.Description;
                examSession.IsActive = true;

                unitOfWork.ExamSessions.Add(examSession);
                
                unitOfWork.Complete();
                //var examSessionId = examSession.ExamSessionId;
                //var courses = unitOfWork.Courses.GetAll();

                //foreach (var course in courses)
                //{
                //    var courseExamSession = new CourseExamSession();
                //    courseExamSession.CourseCode = course.CourseCode;

                //    courseExamSession.ExamSessionId = examSessionId;
                //    unitOfWork.CourseExamSessions.Add(courseExamSession);
                //    unitOfWork.Complete();

                //    var exam = new Exam();
                //    exam.Name = course.CourseName;
                //    exam.Description = $"Session d'exam du cours {course.CourseName}";
                //    exam.CourseExamSessionId = courseExamSession.CourseExamSessionId;
                //    unitOfWork.Exams.Add(exam);
                //    unitOfWork.Complete();
               // }
                
                //exam.Date = model.Date;
                //exam.CourseExamSessionId = examSession.ExamSessionId;


                TempData["Message"] = "La session a été enregistrer avec succès";
                return RedirectToAction("AddExamSession"); ;
            }
            return View(model);
        }
    }
}