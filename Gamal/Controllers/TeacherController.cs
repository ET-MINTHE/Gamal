using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gamal.Controllers
{
    public class TeacherController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public TeacherController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>
            signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Teacher()
        {
            var user = await userManager.FindByEmailAsync(HttpContext.Session.GetString("Email"));

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            var teacher = unitOfWork.Teachers.Find(t => t.SerialNumber == user.SerialNumber).FirstOrDefault();
            
            //var department = unitOfWork.Departments.Find(d => d.DepartmentCode == student.DepartmentCode).FirstOrDefault();
            //var model = new StudentHomeViewModel();
            return View();  
        }
    }
}