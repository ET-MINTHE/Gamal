using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamal.Models;
using Gamal.Models.Domain;
using Gamal.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gamal.Controllers
{
    public class CourseDescriptionController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public CourseDescriptionController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string courseId, string departmentCode)
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var course = await unitOfWork.Courses.GetCourseWithDepartment(courseId);
            var model = new BookletViewModel();
            var email = HttpContext.Session.GetString("Email");

            var user = await userManager.FindByEmailAsync(email);
            bool status = await unitOfWork.Booklets.IsExamPassedByStudent(user.SerialNumber, courseId);
            model.Status = status;
            Booklet booklet = null;
            if (status == true)
            {
                booklet = await unitOfWork.Booklets.GetStudentMarkByCourse(user.SerialNumber, courseId);
            }
           
            if (booklet != null)
            {
                model.ExamDate = booklet.Date;
                model.Mark = booklet.Mark;
            }
            else
            {
                model.ExamDate = null;
                model.Mark = 0;
            }
            model.Year = course.Year;
            model.Length = course.Length;
            model.Description = course.Description;
            model.Course = course.CourseName;
            model.DepartmentName = course.Department.DepartmentName;
            model.Weight = course.Weight;
            model.Sector = course.Sector;
            return View(model);
        }
    }
}