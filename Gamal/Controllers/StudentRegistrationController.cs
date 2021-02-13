using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gamal.Models;
using Gamal.Models.Domain;
using Gamal.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Gamal.Controllers
{
   [Authorize]
    public class StudentRegistrationController : Controller
    {
        private StudentRegistrationViewModel studentModel;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
		  private readonly RoleManager<IdentityRole> roleManager;
		  private readonly IConfiguration config;
        public StudentRegistrationController(SignInManager<ApplicationUser>
            signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
        {
            studentModel = new StudentRegistrationViewModel();
            this.signInManager = signInManager;
            this.userManager = userManager;
			this.roleManager = roleManager;
			this.config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Index()    
        {
            var model = new StudentPersonalInfoViewModel();
            ViewBag.Message = TempData["Message"]?.ToString();
            return View(model);
        }

        [HttpGet]
        public IActionResult StudentPersonalInfos()
        {
            var model = new StudentPersonalInfoViewModel();
            model.DateOfBirth = DateTime.Now;
            //Thread.Sleep(3000);
            return View(model);
        }
            
        [HttpPost]
        public async Task<IActionResult> StudentPersonalInfos(StudentPersonalInfoViewModel model, string button)
        {
            if (ModelState.IsValid)
            {
                //var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                //var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
                var student = await userManager.FindByEmailAsync(model.Email);
               
                if (student != null)
                {
                    ViewBag.ErrorMessage = $"L'adresse electronique {model.Email} existe déjà dans la base de donnée";
                    return View(model);
                }

                TempData["FirstName"] = model.FirstName;
                TempData["LastName"] = model.LastName;
                TempData["DateOfBirth"] = model.DateOfBirth;
                TempData["Nationality"] = model.Nationality;
                TempData["CityOfBirth"] = model.CityOfBirth;
                TempData["Email"] = model.Email;
                return RedirectToAction("StudentContact");
            }
            
            return View(model);
        }

        [HttpGet]
        public IActionResult StudentContact()
        {
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

            model.HighSchoolGraduateYear = DateTime.Now;

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

            return View(model);
        }

        [HttpPost]
        public IActionResult StudentFacultyInfos(StudentFacultyViewModel model, string button)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
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
            
            if (button == "first")
            {
                return RedirectToAction("HighSchoolInfos");
            }

            if (ModelState.IsValid)
            {
                var existStudent = unitOfWork.UserStudents.ExistStudentWithSerialNumber(model.SerialNumber);
                
                if (existStudent)
                {
                    ViewBag.ErrorMessage = $"L'étudiant avec le matricule {model.SerialNumber} existe déjà dans la base de donnée";
                    return View(model);
                }
                DateTime enrollmentYear = DateTime.Now;
                string monthOfEnrollment = DateTime.Now.ToString("MM");
                if (!(Int32.Parse(monthOfEnrollment) > 9 && Int32.Parse(monthOfEnrollment) < 12))
                {
                    enrollmentYear = enrollmentYear.AddYears(-1);
                }

                TempData["CurrentYear"] = model.CurrentYear;
                TempData["Department"] = model.Department;
                TempData["Faculty"] = model.Faculty;
                TempData["YearOfEnrolement"] = enrollmentYear;
                TempData["SerialNumber"] = model.SerialNumber;
                TempData["PartTime"] = model.PartTime;
                TempData["StudentProfile"] = model.StudentProfile;

                return RedirectToAction("ConfirmStudentEnrollment");
            }

            ViewBag.ErrorMessage = $"Impossible d'inscrire l'étudiant {TempData["FirstName"]?.ToString()} {TempData["LastName"]?.ToString()}";
           
            return View(model);
        }

        [HttpGet]
        public ActionResult ConfirmStudentEnrollment()
        {
            var model = new StudentRegistrationViewModel();
            model.FirstName = TempData["FirstName"]?.ToString();
            model.LastName = TempData["LastName"]?.ToString();
            model.DateOfBirth = (DateTime)TempData["DateOfBirth"];
            model.Nationality = TempData["Nationality"]?.ToString();
            model.CityOfBirth = TempData["CityOfBirth"]?.ToString();
            model.Email = TempData["Email"]?.ToString();
            model.Address = TempData["Address"]?.ToString();
            model.CityOfResidence = TempData["CityOfResidence"]?.ToString();
            model.PhoneNumber = TempData["PhoneNumber"]?.ToString();
            model.UserName = TempData["Email"]?.ToString();
            model.HighSchool = TempData["HighSchool"]?.ToString();
            model.HighSchoolOption = TempData["HighSchoolOption"]?.ToString();
            model.HighSchoolMark = (int)TempData["HighSchoolMark"];
            model.HighSchoolGraduateYear = (DateTime)TempData["HighSchoolGraduateYear"];
            model.CurrentYear = (int)TempData["CurrentYear"];
            model.Department = TempData["Department"]?.ToString();
            model.Faculty = TempData["Faculty"]?.ToString();
            model.YearOfEnrolement = (DateTime)TempData["YearOfEnrolement"];
            model.SerialNumber = TempData["SerialNumber"]?.ToString();
            model.StudentProfile = TempData["StudentProfile"]?.ToString();
            model.PartTime = TempData["PartTime"]?.ToString();
            return View(model);
        }

        [HttpPost]
        public async  Task<ActionResult> ConfirmStudentEnrollment(StudentRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    Nationality = model.Nationality,
                    CityOfBirth = model.CityOfBirth,
                    Email = model.Email,
                    Address = model.Address,
                    CityOfResidence = model.CityOfResidence,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Email,
                    HighSchool = model.HighSchool,
                    HighSchoolOption = model.HighSchoolOption,
                    HighSchoolMark = model.HighSchoolMark,
                    HighSchoolGraduateYear = model.HighSchoolGraduateYear,
                    CurrentYear = model.CurrentYear,
                    Department = model.Department,
                    Faculty = model.Faculty,
                    YearOfEnrolement = model.YearOfEnrolement,
                    SerialNumber = model.SerialNumber,
                };

                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

                var result = await userManager.CreateAsync(user, "Fantabamba25?!1_");
                if (result.Succeeded)
                {
                  TempData["enrolementState"] = "succeed";
                  TempData["Message"] = $"L'inscription de l'étudiant {user.FirstName} {user.LastName} a été completée avec succes";

                  var student = new UserStudent();
                  var department = unitOfWork.Departments.Find(d => d.DepartmentName == model.Department).FirstOrDefault();

                  student.DepartmentCode = department.DepartmentCode;
                  // student.Department = department;
                  student.SerialNumber = model.SerialNumber;
                  student.Profile = model.StudentProfile;
                  student.PartTime = model.PartTime == "SI" ? true : false;
                  student.Email = model.Email;
                  student.DepartmentCode = department.DepartmentCode;
                  unitOfWork.UserStudents.Add(student);

                  var role = await roleManager.FindByNameAsync("Student");
                  if (role == null)
                  {
                        role = new IdentityRole();
                        role.Name = "Student";
                        var result1 = await roleManager.CreateAsync(role);
                        if (!result1.Succeeded)
                        {
                           ViewBag.Error = $"Une erreur est survenue durant la creation du role Etudiant!";
                           return View(model);
                        }
                  }

                  var result2 = await userManager.AddToRoleAsync(user, "Student");
                  if (!result2.Succeeded)
                  {
                     ViewBag.Error = $"Impossible d'ajouter l'utilisateur {user.FirstName} {user.LastName} au role Secrétaire";
                     return View(model);
                  }

                  unitOfWork.Complete();

                 // SendEmailConfirmation(student.Email);
                  return RedirectToAction("Index", "StudentRegistration");
                    
                }
            }

            return View();
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