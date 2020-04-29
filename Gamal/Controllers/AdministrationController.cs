using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Gamal.Models;
using Gamal.Models.Domain;
using Gamal.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gamal.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHostingEnvironment hostingEnvironment;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditUserRole()
        {
            var model = new UserRoleViewModel();
            model.AllRoles = new List<SelectListItem>();
            model.AllRoles = new SelectList(roleManager.Roles.Select(r => r.Name).ToList());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserRole(UserRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByNameAsync(model.RoleName);
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role with name = {model.RoleName} cannot be found";
                    return View(model);
                }
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with name = {model.UserName} cannot be found";
                    return View(model);
                }
                IdentityResult result = null;
                if (model.IsSelected && !(await userManager.IsInRoleAsync(user, model.RoleName)))
                {
                    result = await userManager.AddToRoleAsync(user, model.RoleName);
                }
                else if (model.IsSelected && (await userManager.IsInRoleAsync(user, model.RoleName)))
                {
                    ViewBag.ErrorMessage = $"The user with name {model.UserName} is already in the role {model.RoleName}";
                    return View(model);
                }
                else if (!model.IsSelected && (await userManager.IsInRoleAsync(user, model.RoleName)))
                {
                    result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                }
                else
                {
                    ViewBag.ErrorMessage = $"The user with name {model.UserName} is not in the role {model.RoleName}";
                    return View(model);
                }

                if (!result.Succeeded)
                {
                    ViewBag.ErrorMessage = $"Error durante il processo";
                    return View(model);
                }
            }
            ViewBag.Message = $"L'utente {model.UserName} è stato aggiunto al ruolo {model.RoleName} con successo";
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> CallForExam()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var dollies = unitOfWork.Dollies.GetDollyByTeacher(HttpContext.Session.GetString("SerialNumber"));
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            var exam = unitOfWork.Exams.GetExamByTeacher(user.SerialNumber);
            return View(exam);
        }

        [HttpGet]
        public async Task<IActionResult> AddExam()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            var model = new AddExamViewModel();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            var courses = unitOfWork.Courses.GetCoursesByTeacher(user.SerialNumber);
            var courseList = new List<string>();
            foreach (var item in courses)
            {
                courseList.Add(item.CourseName);
            }
            model.AllCourses = new SelectList(courseList);
            var sessionList = new List<string>();
            var sessions = unitOfWork.ExamSessions.GetAll();
            foreach (var item in sessions)
            {
                sessionList.Add(item.Name);
            }

            ViewBag.Message = TempData["Message"]?.ToString();
            TempData["Message"] = "";
            model.AllSessions = new SelectList(sessionList);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddExam(AddExamViewModel model)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            if (ModelState.IsValid)
            {
                var examSession = unitOfWork.ExamSessions.Find(es => es.Name == model.Session).FirstOrDefault();
                var courseExamSession = unitOfWork.CourseExamSessions.Find(d => d.ExamSessionId == examSession.ExamSessionId).FirstOrDefault();
                var exam = new Exam();
                exam.Name = model.Course;
                exam.Description = model.Description;
                exam.Date = model.Date;
                exam.CourseExamSessionId = courseExamSession.CourseExamSessionId;
                exam.Hour = model.Hour;
                exam.TeacherSerialNumber = user.SerialNumber;
                exam.Classroom = model.Classroom;

                unitOfWork.Exams.Add(exam);
                unitOfWork.Complete();
                TempData["Message"] = "L'appel d'examen a été enregistrer avec succès";
                return RedirectToAction("AddExam");
            }

            

            var courses = unitOfWork.Courses.GetCoursesByTeacher(user.SerialNumber);
            var courseList = new List<string>();
            foreach (var item in courses)
            {
                courseList.Add(item.CourseName);
            }
            model.AllCourses = new SelectList(courseList);
            var sessionList = new List<string>();
            var sessions = unitOfWork.ExamSessions.GetAll();
            foreach (var item in sessions)
            {
                sessionList.Add(item.Name);
            }

            model.AllSessions = new SelectList(sessionList);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ExamListForStudent()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            var examList = new List<ELSVIEViewModel>();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var department = unitOfWork.Departments.Find(d => d.DepartmentName == user.Department).FirstOrDefault();
            var exams = unitOfWork.Exams.GetExamByDepartment(department.DepartmentCode);
            foreach (var exam in exams)
            {
                var ex = new ELSVIEViewModel();
                ex.Date = exam.Date;
                ex.Description = exam.Description;
                ex.Classroom = exam.Classroom;
                ex.ExamId = exam.ExamId;
                ex.Name = exam.Name;
                ex.Hour = exam.Hour;
                ex.IsResered = unitOfWork.ExamEnrollments.IsExamEnrollmentReserved(user.SerialNumber, exam.ExamId) == true ? "Reservé" : "Non Reservé";
                examList.Add(ex);
            }
            return View(examList);
        }
        [HttpGet]
        public async Task<IActionResult> ExamEnrollment(string examId, string isReserved)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            if (isReserved == "Non Reservé")
            {
                var enrollment = new ExamEnrollment();
                enrollment.ExamId = Int32.Parse(examId);
                enrollment.SerialNumber = user.SerialNumber;

                unitOfWork.ExamEnrollments.Add(enrollment);
                unitOfWork.Complete();
            }
            else
            {
                var enrollment = unitOfWork.ExamEnrollments.GetEnrollmentByExam(Int32.Parse(examId));
                unitOfWork.ExamEnrollments.Remove(enrollment);
                unitOfWork.Complete();
            }

            return RedirectToAction("ExamListForStudent");
        }
        [HttpGet]
        public async Task<IActionResult> StudentDepartment()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            var departement = unitOfWork.Departments.GetDepartmentAndFaculty(user.Department);
            var model = new StudentDepartmentViewModel();
            model.Department = departement.DepartmentName;
            model.DepartmentCode = departement.DepartmentCode;
            model.Faculty = departement.Faculty.FacultyName;
            model.FacultyCode = departement.Faculty.FacultyCode;
            model.CourseType = departement.CourseType;
            model.Credit = "Pas defini";
            model.EnrollmentYeart = user.YearOfEnrolement.ToString("yyyy");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> StudentDolly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            
            var user = await userManager.FindByEmailAsync(email);
            ViewBag.Department = user.Department;
            var courses = unitOfWork.Courses.GetCourseByDepartment(user.Department);
            return View(courses);
        }


        [HttpGet]
        public async Task<IActionResult> TeacherDolly()
        {   
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            var courses = unitOfWork.Courses.GetCoursesByTeacher(user.SerialNumber);

            return View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> AddToDolly(string courseCode, string departmentCode)
        {   
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);   
            
            var model = new UploadToDollyViewModel();
            model.Dollies = unitOfWork.Dollies.GetDollyByTeacher(user.SerialNumber).ToList();

            var course = unitOfWork.Courses.Get(courseCode);
            model.CourseCode = courseCode;
            model.DepartmentCode = departmentCode;
            model.CourseName = course.CourseName;
            model.TeacherSerialNumber = user.SerialNumber;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToDolly(UploadToDollyViewModel model, string serialNumber, string courseCode, string departmentCode)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            model.Dollies = unitOfWork.Dollies.GetDollyByTeacher(serialNumber).ToList();
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.FileToUpload != null)
                {
                    string uploadsFolder     = Path.Combine(hostingEnvironment.WebRootPath, "dolly");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileToUpload.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.FileToUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                    Dolly dolly = new Dolly
                    {
                        FilePath = uniqueFileName,
                        CourseCode = courseCode,
                        TeacherSerialNumber = serialNumber,
                        FileName = model.FileName
                    };
                    unitOfWork.Dollies.Add(dolly);
                    unitOfWork.Complete();
                }
                return RedirectToAction("AddToDolly", new { courseCode = courseCode, departmentCode = departmentCode } );
            }
            model.DepartmentCode = departmentCode;
            model.CourseCode = courseCode;
            model.TeacherSerialNumber = serialNumber;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromDolly(string id, string courseCode, string departmentCode)
        {   
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            var model = new UploadToDollyViewModel();
            var dolly = unitOfWork.Dollies.Get(Int32.Parse(id));
            unitOfWork.Dollies.Remove(dolly);
            unitOfWork.Complete();

            return RedirectToAction("AddToDolly", new { departmentCode = departmentCode, courseCode = courseCode });
        }
        [HttpGet]
        public async Task<IActionResult> StudentCourseDolly(string courseId, string departmentId)   
        {
            if (!String.IsNullOrEmpty(courseId) && !String.IsNullOrEmpty(departmentId))
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

                var dollies = unitOfWork.Dollies.GetDollyByCourse(courseId);

                ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
                ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
                ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
                var email = HttpContext.Session.GetString("Email");

                var user = await userManager.FindByEmailAsync(email);
                ViewBag.Course = unitOfWork.Courses.Get(courseId).CourseName;
                var courses = unitOfWork.Courses.GetCourseByDepartment(user.Department);
                return View(dollies);
            }
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegisterMark()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            var model = new RegisterMarkViewModel();
            var marks = new List<int>();
            for (int index = 10; index <= 20; index++)
            {
                marks.Add(index);
            }
            model.AllMarks = new SelectList(marks);

            var courses = unitOfWork.Courses.GetCoursesByTeacher(user.SerialNumber);
            var allCourses = new List<string>();
            foreach (var course in courses)
            {
                allCourses.Add(course.CourseName);
            }
            model.AllCourses = new SelectList(allCourses);
            ViewBag.Message = "";
            if (String.IsNullOrEmpty(TempData["message"]?.ToString()))
            {
                ViewBag.Message = TempData["message"]?.ToString();
                TempData["message"] = "";
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterMark(RegisterMarkViewModel model)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            var marks = new List<int>();
            for (int index = 10; index <= 20; index++)
            {
                marks.Add(index);
            }
            model.AllMarks = new SelectList(marks);

            var courses = unitOfWork.Courses.GetCoursesByTeacher(user.SerialNumber);
            var allCourses = new List<string>();
            foreach (var course in courses)
            {
                allCourses.Add(course.CourseName);
            }
            model.AllCourses = new SelectList(allCourses);

            var student = unitOfWork.UserStudents.Get(model.StudentSerialNumber);
            if (student == null)
            {
                ViewBag.Error = $"Aucun étudiant trouvé avec le matricule {model.StudentSerialNumber}";
                return View(model);
            }
           
            if (ModelState.IsValid)
            {
                var booklet = new Booklet
                {
                    StudentSerialNumber = model.StudentSerialNumber,
                    TeacherSerialNumber = user.SerialNumber,
                    Mark = model.Mark,
                    Date = DateTime.Now,
                    CourseCode = unitOfWork.Courses.Find(c => c.CourseName == model.CourseName).FirstOrDefault().CourseCode
                };

                unitOfWork.Booklets.Add(booklet);
                unitOfWork.Complete();
                ViewBag.Message = $"Le note de l'étudiant a été enregistre avec succes!";
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CourseProgram()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> StudentEnrollment()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            return View();
        }
            
        [HttpGet]
        public async Task<IActionResult> Graduation()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PartialTest()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Fees()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("UserFirstName");
            ViewBag.LastName = HttpContext.Session.GetString("UserLastName");
            ViewBag.SerialNumber = HttpContext.Session.GetString("SerialNumber");
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            return View();
        }
    }   
}