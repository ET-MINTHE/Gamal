﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamal.Models;
using Gamal.Models.Domain;
using Gamal.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Gamal.Controllers
{
    public class TeacherRegistrationController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<TeacherRegistrationController> logger;

        public TeacherRegistrationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>
            signInManager, ILogger<TeacherRegistrationController> logger, IConfiguration config,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            ViewBag.Message = TempData["Message"];
            TempData["Message"] = "";

            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            var model = new TeacherRegistrationViewModel();
            var departments = unitOfWork.Departments.GetAll().ToList();
            var departmentList = new List<string>();

            foreach (var item in departments)
            {
                departmentList.Add(item.DepartmentName);
            }
            model.Departments = new SelectList(departmentList);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TeacherRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var teacher = new UserTeacher();
                teacher.SerialNumber = model.SerialNumber;

                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

                var department = unitOfWork.Departments.Find(d => d.DepartmentName == model.Department).FirstOrDefault();

                teacher.DepartmentCode = department.DepartmentCode;
                teacher.Office = model.Office;

                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.FirstName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Email,
                    Department = model.Department,
                    SerialNumber = model.SerialNumber
                };

                var result = await userManager.CreateAsync(user, "Fantabamba25?!1_");

                if (result.Succeeded)
                {
                    result = await userManager.AddToRoleAsync(user, "Teacher");
                    if (result.Succeeded)
                    {
                        unitOfWork.Teachers.Add(teacher);
                        unitOfWork.Complete();
                        TempData["Message"] = $"Inscription de l'enseignant {model.FirstName} {model.LastName} completée avec succes!";
                        return RedirectToAction("Index");
                    }
                    ViewBag.Error = $"Une erreur est survenue durant l'inscription de l'enseignant {model.FirstName} {model.LastName}!";
                    return View(model);
                }
                ViewBag.Error = $"Une erreur est survenue durant l'inscription de l'enseignant {model.FirstName} {model.LastName}!";
                return View(model);
            }
            ViewBag.Error = $"Une erreur est survenue durant l'inscription de l'enseignant {model.FirstName} {model.LastName}!";
            return View(model);
        }
    }
}