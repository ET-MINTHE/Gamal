using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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

namespace Gamal.Controllers
{
    public class StudentRegistrationController : Controller
    {
        private StudentRegistrationViewModel studentModel;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public StudentRegistrationController(SignInManager<ApplicationUser>
            signInManager, UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            studentModel = new StudentRegistrationViewModel();
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.config = config;
        }

        [HttpGet]
        public IActionResult Index()    
        {
            if (TempData["enrolementState"]?.ToString() == "succeed")
            {
                ViewBag.message = "succeed";
            }
            return View();
        }

        [HttpGet]
        public IActionResult StudentPersonalInfos()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var model = new StudentPersonalInfoViewModel();
            return View(model);
        }
            
        [HttpPost]
        public IActionResult StudentPersonalInfos(StudentPersonalInfoViewModel model, string button)
        {
            if (ModelState.IsValid)
            {
                TempData["FirstName"] = model.FirstName;
                TempData["LastName"] = model.LastName;
                TempData["DateOfBirth"] = model.DateOfBirth;
                TempData["Nationality"] = model.Nationality;
                TempData["CityOfBirth"] = model.CityOfBirth;
                TempData["Email"] = model.Email;
                return RedirectToAction("StudentContact");
            }
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            return View(model);
        }

        [HttpGet]
        public IActionResult StudentContact()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            return View();
        }

        [HttpPost]
        public IActionResult StudentContact(StudentContactViewModel model, string button)
        {
            if (ModelState.IsValid)
            {
                if (button == "first")
                {
                    return RedirectToAction("StudentPersonalInfos");
                }
                else
                {
                    TempData["Address"] = model.Address;
                    TempData["CityOfResidence"] = model.CityOfResidence;
                    TempData["PhoneNumber"] = model.PhoneNumber;
                    return RedirectToAction("HighSchoolInfos");
                }
            }
            if (button == "first")
            {
                return RedirectToAction("StudentPersonalInfos");
            }

            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            return View(model);
        }

        [HttpGet]
        public IActionResult HighSchoolInfos()
        {
            var allMarks = new List<int>();
            for (int mark = 10; mark <= 20; mark++)
            {
                allMarks.Add(mark);
            }
            var model = new HighSchoolInfoViewModel();
            var allHighSchools = new List<string>();
            allHighSchools.Add("LYCEE FILY DE COYAH");
            allHighSchools.Add("LYCEE DE YIMBAYAH");
            allHighSchools.Add("LYCEE DE KAMSAR");

            var allHighSchoolOptions = new List<string>();
            allHighSchoolOptions.Add("SCIENCE SOCIALE");
            allHighSchoolOptions.Add("SCIENCE EXPERIMENTALE"); 
            allHighSchoolOptions.Add("SCIENCE MATHEMATIQUE");
           
            model.AllHighSchoolMarks = new SelectList(allMarks);
            model.AllHighSchoolOptions = new SelectList(allHighSchoolOptions);
            model.AllHighSchools = new SelectList(allHighSchools);

            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");

            return View(model);
        }

        [HttpPost]
        public IActionResult HighSchoolInfos(HighSchoolInfoViewModel model, string button)
        {

            if (ModelState.IsValid)
            {
                if (button == "first")
                {
                    return RedirectToAction("StudentContact");
                }
                else
                {
                    TempData["HighSchool"] = model.HighSchool;
                    TempData["HighSchoolOption"] = model.HighSchoolOption;
                    TempData["HighSchoolMark"] = model.HighSchoolMark;
                    TempData["HighSchoolGraduateYear"] = model.HighSchoolGraduateYear;
                    return RedirectToAction("StudentFacultyInfos");
                }
            }else
            {
                if (button == "first")
                {
                    return RedirectToAction("StudentContact");
                }
                else
                {
                    var allMarks = new List<int>();
                    for (int mark = 10; mark <= 20; mark++)
                    {
                        allMarks.Add(mark);
                    }
                    var allHighSchools = new List<string>();
                    allHighSchools.Add("LYCEE FILY DE COYAH");
                    allHighSchools.Add("LYCEE DE YIMBAYAH");
                    allHighSchools.Add("LYCEE DE KAMSAR");

                    var allHighSchoolOptions = new List<string>();
                    allHighSchoolOptions.Add("SCIENCE SOCIALE");
                    allHighSchoolOptions.Add("SCIENCE EXPERIMENTALE");
                    allHighSchoolOptions.Add("SCIENCE MATHEMATIQUE");

                    model.AllHighSchoolMarks = new SelectList(allMarks);
                    model.AllHighSchoolOptions = new SelectList(allHighSchoolOptions);
                    model.AllHighSchools = new SelectList(allHighSchools);
                    ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
                    ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
                    ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
                    return View(model);
                }
            }
        }

        [HttpGet]
        public IActionResult StudentFacultyInfos()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            var allYears = new List<int>();
            for (int mark = 1; mark <= 6; mark++)
            {
                allYears.Add(mark);
            }
            var model = new StudentFacultyViewModel();
            var allDepartments = new List<string>();
            var allFaculties = new List<string>();
            allDepartments.Add("Selectionner le Département");

            allFaculties = unitOfWork.Faculties.GetFacultiesNames().ToList();
            allFaculties.Insert(0, "Selectionner la faculté");
           
            var partTimes = new List<string>();
            partTimes.Add("SI");
            partTimes.Add("NO");

            var studentProfiles = new List<string>();
            studentProfiles.Add("ETUDIANT STANDARD");
            studentProfiles.Add("ETUDIANT NON STANDARD");

            model.StudentProfiles = new SelectList(studentProfiles);
            model.PartTimes = new SelectList(partTimes);
            model.AllDepartments = new SelectList(allDepartments);
            model.AllFaculties = new SelectList(allFaculties);
            model.AllCurrentYears = new SelectList(allYears);

            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> StudentFacultyInfos(StudentFacultyViewModel model, string button)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            if (button == "first")
            {
                return RedirectToAction("HighSchoolInfos");
            }

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = TempData["FirstName"]?.ToString(),
                    LastName = TempData["LastName"]?.ToString(),
                    DateOfBirth = (DateTime)TempData["DateOfBirth"],
                    Nationality = TempData["Nationality"]?.ToString(),
                    CityOfBirth = TempData["CityOfBirth"]?.ToString(),
                    Email = TempData["Email"]?.ToString(),
                    Address = TempData["Address"]?.ToString(),
                    CityOfResidence = TempData["CityOfResidence"]?.ToString(),
                    PhoneNumber = TempData["PhoneNumber"]?.ToString(),
                    UserName = TempData["Email"]?.ToString(),
                    HighSchool = TempData["HighSchool"]?.ToString(),
                    HighSchoolOption = TempData["HighSchoolOption"]?.ToString(),
                    HighSchoolMark = (int)TempData["HighSchoolMark"],
                    HighSchoolGraduateYear = (DateTime)TempData["HighSchoolGraduateYear"],
                    CurrentYear = model.CurrentYear,
                    Department = model.Department,
                    Faculty = model.Faculty,
                    YearOfEnrolement = model.YearOfEnrolement,
                    SerialNumber = model.SerialNumber
                };

                var result = await userManager.CreateAsync(user, "Fantabamba25?!1_");
                if (result.Succeeded)
                {
                    result = await userManager.AddToRoleAsync(user, "Student");
                    if (result.Succeeded)
                    {
                        TempData["enrolementState"] = "succeed";
                        TempData["Message"] = "L'inscription a été completée avec succes";

                        var student = new UserStudent();
                        var department = unitOfWork.Departments.Find(d => d.DepartmentName == model.Department).FirstOrDefault();

                        student.DepartmentCode = department.DepartmentCode;
                        // student.Department = department;
                        student.SerialNumber = model.SerialNumber;
                        student.Profile = model.StudentProfile;
                        student.PartTime = model.PartTime == "SI" ? true : false;
                        unitOfWork.UserStudents.Add(student);
                        student.Email = TempData["Email"]?.ToString();
                        unitOfWork.Complete();

                        SendEmailConfirmation(student.Email);
                        return RedirectToAction("Home", "Secretary");
                    }
                }
            }

            ViewBag.ErrorMessage = $"Impossible d'inscrire l'étudiant {TempData["FirstName"]?.ToString()} {TempData["LastName"]?.ToString()}";
            var allYears = new List<int>();
            for (int mark = 1; mark <= 6; mark++)
            {
                allYears.Add(mark);
            }
                
            var allDepartments = new List<string>();
            var allFaculties = new List<string>();
            allDepartments.Add("Selectionner le Département");

            allFaculties = unitOfWork.Faculties.GetFacultiesNames().ToList();
            allFaculties.Insert(0, "Selectionner la faculté");

            var partTimes = new List<string>();
            partTimes.Add("SI");
            partTimes.Add("NO");

            var studentProfiles = new List<string>();
            studentProfiles.Add("ETUDIANT STANDARD");
            studentProfiles.Add("ETUDIANT NON STANDARD");

            model.StudentProfiles = new SelectList(studentProfiles);
            model.PartTimes = new SelectList(partTimes);
            model.AllDepartments = new SelectList(allDepartments);
            model.AllFaculties = new SelectList(allFaculties);
            model.AllCurrentYears = new SelectList(allYears);

            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            return View(model);
        }

        [HttpGet]
        public JsonResult GetDepartmentById(string facultyCode)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var departments = unitOfWork.Departments.GetDepartmentByFacultyName(facultyCode).ToList();
            departments.Insert(0, "Selectioner le département");
            return new JsonResult(departments);
        }

        public void SendEmailConfirmation(string email)
        {
            var user = userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
            var token = userManager.GenerateEmailConfirmationTokenAsync(user).GetAwaiter().GetResult();

            var confirmEmailLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);
            signInManager.SignInAsync(user, isPersistent: false).GetAwaiter().GetResult();

            MailMessage mailMessage = new MailMessage("elhadjtahirou.minthe@gmail.com", email);
            StringBuilder messageBody = new StringBuilder();
            messageBody.Append("UNIVERSITE GAMAL ABDEL NASSER DE CONAKRY" + Environment.NewLine);
            messageBody.Append("Cher " + user.FirstName + " " + user.LastName + Environment.NewLine);
            messageBody.Append($"Nous avons le plaisir de vous annoncer que votre nom d'utilisateur est {user.UserName}"+ Environment.NewLine);
            messageBody.Append("Veuillez cliquer sur le lien ci-dessous pour initialiser votre nom d'utilisateur" + Environment.NewLine);
            messageBody.Append(confirmEmailLink + Environment.NewLine);
            messageBody.Append("UGANC");

            mailMessage.Subject = "Initialisation du nom d'utilisateur";
            mailMessage.Body = messageBody.ToString();

            var credentials = new NetworkCredential(config.GetValue<string>("Email:Smtp:Username"), config.GetValue<string>("Email:Smtp:Password"));
            var smtpClient = new SmtpClient()
            {
                Port = config.GetValue<int>("Email:Smtp:Port"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,  
                Host = config.GetValue<string>("Email:Smtp:Host"),
                EnableSsl = true,
                Credentials = credentials
            };
            smtpClient.Send(mailMessage);
        }
    }   
}