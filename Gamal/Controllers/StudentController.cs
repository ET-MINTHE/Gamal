using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamal.Models;
using Gamal.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gamal.Controllers
{
    public class StudentController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public StudentController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>
            signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Home() 
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var user = await userManager.FindByEmailAsync(HttpContext.Session.GetString("Email"));

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            var student = unitOfWork.UserStudents.Find(u => u.SerialNumber == user.SerialNumber).FirstOrDefault();
            var department = unitOfWork.Departments.Find(d => d.DepartmentCode == student.DepartmentCode).FirstOrDefault();

            var model = new StudentHomeViewModel();

            model.Course = department.DepartmentName;
            model.CourseType = department.CourseType;
            model.CurrentYear = user.CurrentYear;
            model.EnrollmentYear = user.YearOfEnrolement.ToString("dd:MM:yyyy");
            model.PartTime = student.PartTime == true? "SI": "NO";
            model.StudentProfile = student.Profile;
            var date = user.YearOfEnrolement.AddYears(1);
            model.AccademicYear = user.YearOfEnrolement.ToString("yyyy")+"/"+date.ToString("yyyy");

            return View(model);
        }
    }
}