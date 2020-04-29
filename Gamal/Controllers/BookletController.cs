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
    public class BookletController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public BookletController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var model = new List<BookletViewModel>();

            var booklets = unitOfWork.Booklets.GetBookletByStudent(user.SerialNumber);

            int sum = 0;
            int sumWeightedMark = 0;    
            int sumWeight = 0;
            int countMark = 0;
                
            foreach (var booklet in booklets)
            {
                var item = new BookletViewModel
                {
                    Course = booklet.Course.CourseName,
                    CourseCode = booklet.Course.CourseCode,
                    DepartmentName = booklet.Course.Department.DepartmentName,
                    DepartmentCode = booklet.Course.Department.DepartmentCode,
                    ExamDate = booklet.Date,
                    Mark = booklet.Mark,
                    Year = booklet.Course.Year,
                    Weight = booklet.Course.Weight,
                    Status = true
                };

                sumWeightedMark += booklet.Mark * booklet.Course.Weight;
                sumWeight += booklet.Course.Weight;
                sum += booklet.Mark;
                countMark += 1;

                model.Add(item);
            }

            var courses = unitOfWork.Courses.GetCourseByDepartment(user.Department);

            foreach (var item in courses)
            {
                if (model.Exists(b => b.Course == item.CourseName) == false)
                {
                    var elem = new BookletViewModel
                    {
                        Course = item.CourseName,
                        CourseCode = item.CourseCode,
                        DepartmentName = item.Department.DepartmentName,
                        DepartmentCode = item.Department.DepartmentCode,
                        Status = false,
                        Year = item.Year,
                        Weight = item.Weight
                    };
                    model.Add(elem);
                }
            }
            ViewBag.WeightedEverageMark = sumWeightedMark / sumWeight;
            ViewBag.EverageMark = sum / countMark;
            
            return View(model);
        }
    }
}