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
using X.PagedList;
using X.PagedList.Mvc.Core;


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

        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm, int? page, string filter)
        {
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var bookletListViewModel = new BookletListViewModel();
           
            var ViewModel = new List<BookletViewModel>();
            var booklets = unitOfWork.Booklets.GetBookletByStudent(user.SerialNumber, searchTerm);

            int sum = 0;
            int sumWeightedMark = 0;        
            int sumWeight = 0;
            int countMark = 0;

            string all = null;
            string passed = null;
            string notpassed = null;
            if (filter != null)
            {
                if (filter.Equals("all"))
                {
                    all = "all";
                }
                else if (filter.Equals("passed"))
                {
                    passed = "passed";
                }
                else
                {
                    notpassed = "notpassed";
                }
            }

            if (passed != null || all != null || filter == null)
            {
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

                    ViewModel.Add(item);
                }
                if (sumWeight != 0 && countMark != 0)
                {
                    ViewBag.WeightedEverageMark = sumWeightedMark / sumWeight;
                    ViewBag.EverageMark = sum / countMark;
                }
                else
                {
                    ViewBag.WeightedEverageMark = 0;
                    ViewBag.EverageMark = 0;
                }
            }

            if (all != null || notpassed != null || filter == null)
            {
                var courses = unitOfWork.Courses.SearchInDepartment(user.Department, searchTerm).ToList();

                foreach (var item in courses)
                {
                    if (ViewModel.Exists(b => b.Course == item.CourseName) == false)
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
                        ViewModel.Add(elem);
                    }
                }
                
            }
           
            bookletListViewModel.BookletViewModels = ViewModel.ToPagedList(page ?? 1, 4);
            return View(bookletListViewModel);
        }
    }
}