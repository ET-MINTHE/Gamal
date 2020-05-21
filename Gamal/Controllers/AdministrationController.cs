using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Gamal.Models;
using Gamal.Models.Domain;
using Gamal.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using X.PagedList;

namespace Gamal.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IStringLocalizer<AdministrationController> localizer;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment, IStringLocalizer<AdministrationController> localizer)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
            this.localizer = localizer;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult CreateRole()
        {
            ViewBag.Message = localizer["Role Creation"];
            return View();
        }

        [HttpPost]
        //[Authorize]
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
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            var model = new AddExamViewModel();
            model.Date = DateTime.Now;

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
        public async Task<IActionResult> StudentDolly(string searchTerm, int? page, string sortBy)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
         
            var email = HttpContext.Session.GetString("Email");

            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.SortYearParameter = sortBy == "Year" ? "Year desc" : "Year";
            
            var user = await userManager.FindByEmailAsync(email);
            ViewBag.Department = user.Department;
            var courses = unitOfWork.Courses.SearchInDepartment(user.Department, searchTerm);

            var model = new StudentDollyViewModel();
            switch (sortBy)
            {
                case "Name desc":
                    courses = courses.OrderByDescending(c => c.CourseName);
                    break;

                case "Year desc":
                    courses = courses.OrderByDescending(c => c.Year);
                    break;

                case "Year":
                    courses = courses.OrderBy(c => c.Year);
                    break;

                default:
                    courses = courses.OrderBy(c => c.CourseName);
                    break;

            }
            model.ViewModel = courses.ToPagedList(page ?? 1, 8);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> TeacherDolly()
        {   
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
      
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
 
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);   
            
            var model = new UploadToDollyViewModel();
            model.DollyVideos = unitOfWork.DollyVideos.GetDollyVideoByTeacher(user.SerialNumber).ToList();
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
    
            var email = HttpContext.Session.GetString("Email");
            model.Dollies = unitOfWork.Dollies.GetDollyByTeacher(serialNumber).ToList();
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.FileToUpload != null)
                {
                    string uploadsFolder     = Path.Combine(hostingEnvironment.WebRootPath, "dolly");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + (model.FileToUpload.FileName).Replace(" ", "");
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

        [HttpPost]
        public async Task<IActionResult> RemoveFromDolly(string id, string courseCode, string departmentCode)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
   
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            var model = new UploadToDollyViewModel();
            var dolly = unitOfWork.Dollies.Get(Int32.Parse(id));
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "dolly");
            System.IO.File.Delete(Path.Combine(uploadsFolder, dolly.FilePath));
            unitOfWork.Dollies.Remove(dolly);
            unitOfWork.Complete();

            return RedirectToAction("AddToDolly", new { departmentCode = departmentCode, courseCode = courseCode });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFromDolly(string id, string courseCode, string departmentCode)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
         
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            var model = new UploadToDollyViewModel();
            var dolly = unitOfWork.Dollies.Get(Int32.Parse(id));
            model.FileName = dolly.FileName;
            ViewBag.Id = id;
            ViewBag.CourseCode = courseCode;
            ViewBag.DepartmentCode = departmentCode;
            ViewBag.OldPath = dolly.FilePath;
            return View(model);
        }

        [HttpGet]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<IActionResult> UpdateFromDollyVideo(string id, string courseCode, string departmentCode)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
           
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            var model = new UploadToDollyViewModel();
            var dolly = unitOfWork.DollyVideos.Get(Int32.Parse(id));
            model.FileName = dolly.FileName;
            ViewBag.Id = id;
            ViewBag.CourseCode = courseCode;
            ViewBag.DepartmentCode = departmentCode;
            ViewBag.OldPath = dolly.FilePath;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromDollyVideo(UploadToDollyViewModel model, string id, string courseCode, string departmentCode, string oldpath)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
 
            var email = HttpContext.Session.GetString("Email"); 
            var user = await userManager.FindByEmailAsync(email);

            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "dolly_videos");


            var dolly = unitOfWork.DollyVideos.Get(Int32.Parse(id));

            DollyVideo newDolly = null;

            string oldFileName = dolly.FileName;

            if (model.FileToUpload != null)
            {
                System.IO.File.Delete(Path.Combine(uploadsFolder, oldpath));
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + (model.FileToUpload.FileName).Replace(" ", "");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.FileToUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                newDolly = new DollyVideo
                {
                    FilePath = uniqueFileName,
                    CourseCode = courseCode,
                    TeacherSerialNumber = user.SerialNumber,
                    FileName = model.FileName ?? oldFileName
                };
            }
            else
            {
                newDolly = new DollyVideo
                {
                    CourseCode = dolly.CourseCode,
                    FilePath = dolly.FilePath,
                    FileName = model.FileName ?? dolly.FileName,
                    TeacherSerialNumber = dolly.TeacherSerialNumber
                };
            }

            unitOfWork.DollyVideos.Remove(dolly);
            unitOfWork.Complete();
            unitOfWork.DollyVideos.Add(newDolly);
            unitOfWork.Complete();

            return RedirectToAction("AddToDolly", new { departmentCode = departmentCode, courseCode = courseCode });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFromDolly(UploadToDollyViewModel model, string id, string courseCode, string departmentCode, string oldpath)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
       
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "dolly");
            

            var dolly = unitOfWork.Dollies.Get(Int32.Parse(id));

            Dolly newDolly = null;

            string oldFileName = dolly.FileName;
            
            if (model.FileToUpload != null)
            {
                System.IO.File.Delete(Path.Combine(uploadsFolder, oldpath));
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + (model.FileToUpload.FileName).Replace(" ", "");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.FileToUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                newDolly = new Dolly
                {
                    FilePath = uniqueFileName,
                    CourseCode = courseCode,
                    TeacherSerialNumber = user.SerialNumber,
                    FileName = model.FileName ?? oldFileName
                };
            }
            else
            {
                newDolly = new Dolly
                {
                    CourseCode = dolly.CourseCode,
                    FilePath = dolly.FilePath,
                    FileName = model.FileName ?? dolly.FileName,
                    TeacherSerialNumber = dolly.TeacherSerialNumber
                };
            }
           

            unitOfWork.Dollies.Remove(dolly);
            unitOfWork.Complete();
            unitOfWork.Dollies.Add(newDolly);
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
                var model = new UploadToDollyViewModel();
                model.Dollies = unitOfWork.Dollies.GetDollyByCourse(courseId).ToList();
                model.DollyVideos = unitOfWork.DollyVideos.GetDollyVideoByCourse(courseId).ToList();
               
                ViewBag.Course = unitOfWork.Courses.Get(courseId).CourseName;
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegisterMark()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
  
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

            var studentSerialNumber = model.Student.Split(":")[1];
            var student = unitOfWork.UserStudents.Get(studentSerialNumber);
            if (student == null)
            {
                ViewBag.Error = $"Aucun étudiant trouvé avec le matricule {studentSerialNumber}";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var userStudent = unitOfWork.UserStudents.GetStudentBySerialNumber(studentSerialNumber).First();
                var usertTeacher = unitOfWork.Teachers.GetTeacherBySerialNumber(user.SerialNumber).First();

                if (userStudent.DepartmentCode.Equals(usertTeacher.DepartmentCode))
                {
                    var exist = unitOfWork.Booklets.ExistStudentMarkForCourse(studentSerialNumber, user.SerialNumber, unitOfWork.Courses.GetCourseByName(model.CourseName).CourseName);
                    if (unitOfWork.Booklets.ExistStudentMarkForCourse(studentSerialNumber, user.SerialNumber, unitOfWork.Courses.GetCourseByName(model.CourseName).CourseCode) == true)
                    {
                        ViewBag.Error = $"une note de l'étudiant dont le matricule est {studentSerialNumber} pour la matrière {model.CourseName} exist déjà!";
                        return View(model);
                    }
                    var booklet = new Booklet
                    {
                        StudentSerialNumber = studentSerialNumber,
                        TeacherSerialNumber = user.SerialNumber,
                        Mark = model.Mark.Value,
                        Date = DateTime.Now,
                        CourseCode = unitOfWork.Courses.Find(c => c.CourseName == model.CourseName).FirstOrDefault().CourseCode
                    };

                    unitOfWork.Booklets.Add(booklet);
                    unitOfWork.Complete();
                    ViewBag.Message = $"Le note de l'étudiant a été enregistre avec succes!";
                }
                else
                {
                    ViewBag.Error = $"Le note de l'étudiant n'a pas pu etre enregistrer!";
                }
               
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CourseProgram()
        {
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> StudentEnrollment()
        {
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            var currentEnrollment = new StudentEnrollmentViewModel();
            currentEnrollment.EnrollmentYear = user.YearOfEnrolement.ToString("dd/mm/yyyy");
            currentEnrollment.Year = user.CurrentYear;
            int year = user.CurrentYear;
            
            var firtPart = user.YearOfEnrolement.ToString("yyyy");
            int numericalFirtPart = Int32.Parse(firtPart);
            --year;
            numericalFirtPart += year;
            int secondPart = numericalFirtPart + 1;
            currentEnrollment.AccademicYear = numericalFirtPart.ToString() + "/" + secondPart.ToString();
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            currentEnrollment.Department = user.Department;
            var student = unitOfWork.UserStudents.GetStudentBySerialNumber(user.SerialNumber).FirstOrDefault();
            currentEnrollment.PartTime = student.PartTime;
            currentEnrollment.State = true;

            return View(currentEnrollment);
        }
            
        [HttpGet]
        public async Task<IActionResult> Graduation()
        {
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PartialTest()
        {
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Fees()
        {
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var model = unitOfWork.StudentFees.FindFeeByStudent(user.SerialNumber).ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(ProfileViewModel model)
        {
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var oldprofile = unitOfWork.Profiles.Find(p => p.SerialNumber == user.SerialNumber).FirstOrDefault();
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.FileToUpload != null)
                {
                    string extension = System.IO.Path.GetExtension(model.FileToUpload.FileName);
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" ||extension.ToLower() == ".png")
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "profiles");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileToUpload.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.FileToUpload.CopyTo(new FileStream(filePath, FileMode.Create));

                        if (oldprofile != null)
                        {
                            if (System.IO.File.Exists(Path.Combine(uploadsFolder, oldprofile.FilePath)))
                            {
                                System.IO.File.Delete(Path.Combine(uploadsFolder, oldprofile.FilePath));
                                unitOfWork.Profiles.Remove(oldprofile);
                                unitOfWork.Complete();
                            }
                        }
                        
                        Profile profile = new Profile
                        {
                            FilePath = uniqueFileName,
                            SerialNumber = user.SerialNumber,
                        };
                        HttpContext.Session.SetString("ProfilePath", uniqueFileName);
                        unitOfWork.Profiles.Add(profile);
                        unitOfWork.Complete();
                        ViewBag.Message = "Votre profile a été mis à jour!";
                        if (User.IsInRole("Secretary"))
                        {
                            return RedirectToAction("Home", "Secretary");
                        }
                        else if (User.IsInRole("Student"))
                        {
                            return RedirectToAction("Home", "Student");
                        }
                        else if(User.IsInRole("Teacher"))
                        {
                            return RedirectToAction("Teacher", "Teacher");
                        }
                    }
                }
            }
            if (User.IsInRole("Secretary"))
            {
                return RedirectToAction("UpdateProfile", "Administration");
            }
            else if (User.IsInRole("Student"))
            {
                return RedirectToAction("UpdateStudentProfile", "Administration");
            }
            else if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("Teacher", "Teacher");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStudentProfile()
        {   
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);
            return View();
        }

        private void DeleteFiles(IFileProvider physicalFileProvider)
        {
            if (physicalFileProvider is PhysicalFileProvider)
            {
                var directory = physicalFileProvider.GetDirectoryContents(string.Empty);
                foreach (var file in directory)
                {
                    if (!file.IsDirectory)
                    {
                        var fileInfo = new System.IO.FileInfo(file.PhysicalPath);
                        fileInfo.Delete();
                    }
                }
            }
        }
        
       [HttpGet]
        public JsonResult AutocompleteCourse(string term)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var user = userManager.FindByEmailAsync(HttpContext.Session.GetString("Email")).GetAwaiter().GetResult();
            
            var courses = unitOfWork.Courses.GetCourseNameByDepartment(user.Department, term);

            return new JsonResult(courses);
        }

        [HttpGet]
        public IActionResult SecretaryFees()
        {
            var email = HttpContext.Session.GetString("Email");
            return View();
        }

        [HttpGet]
        public IActionResult AddFeePaymentExpiration()
        {
            var model = new UniversityFeeViewModel();
            model.AcademicYear = DateTime.Now;
            model.StartDate = DateTime.Now;
            model.ExpirationDate = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        public IActionResult AddFeePaymentExpiration(UniversityFeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
                var fee = new UniversityFee();
                fee.AcademicYear = model.AcademicYear ?? default(DateTime);
                fee.Description = model.Description.ToString();
                fee.StartDate = model.StartDate ?? default(DateTime);
                fee.ExpirationDate = model.ExpirationDate ?? default(DateTime);
                fee.Ammount = model.Ammount ?? default(float);
                var start = model.StartDate?.ToString("yyyy");
                var accademicYear = model.AcademicYear?.ToString("yyyy");
                var expiration = model.ExpirationDate?.ToString("yyyy");

                if (DateTime.Compare(fee.StartDate, fee.ExpirationDate) >= 0 || !start.Equals(expiration) || !start.Equals(accademicYear) || !expiration.Equals(accademicYear))
                {
                    ViewBag.Error = "La date de debut doit etre inferieur à la date de fin et les dates doivent etre de la meme année";
                    return View(model);
                }
                else if (unitOfWork.UniversityFees.ExistUniversityFeeWithYear(model.AcademicYear ?? default(DateTime)) != false)
                {
                    var firstPart= model.AcademicYear?.ToString("yyyy");
                    var newyear = model.AcademicYear?.AddYears(1);
                    var secondPart = newyear?.ToString("yyyy");
                    ViewBag.Error = $"Les dates limites de payement des taxes pour l'année academique {firstPart}/{secondPart} sont déjà enregistrées";
                    return View(model);
                }
                else
                {
                    ViewBag.Message = $"Les dates limites ont été inserées avec succès!";
                    unitOfWork.UniversityFees.Add(fee);
                    unitOfWork.Complete();
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddFee(string searchTerm)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var model = new SearchStudentViewModel();
            var uf = unitOfWork.UniversityFees.GetUniversityFeeByYear(DateTime.Now);
            if (uf == null)
            {
                ViewBag.Error = $"La période d'immatriculation n'est pas arrivée oubien est passé!";
                return View(model);
            }
            string search = null;
            if (searchTerm != null)
            {
                search = searchTerm.Split(":")[1];
            }
            UserStudent student = null;
            if (search != null)
            {
                student = unitOfWork.UserStudents.GetStudentBySerialNumber(search).FirstOrDefault();
            }
            
            if (student != null)
            {
                var studentViewModel = new StudentViewModel();
                var user = userManager.FindByEmailAsync(student.Email).GetAwaiter().GetResult();
                studentViewModel.Name = user.FirstName + " " + user.LastName;
                studentViewModel.SerialNumber = user.SerialNumber;
                studentViewModel.Email = user.Email;
                model.Ammount = uf.Ammount;
                model.Model = studentViewModel;
            }
            return View(model);      
        }

        [HttpPost]
        public IActionResult AddFee(SearchStudentViewModel model, string serialNumber, string ammount, string email)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            var studentViewModel = new StudentViewModel();
            var user = userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
            studentViewModel.Name = user.FirstName + " " + user.LastName;
            studentViewModel.SerialNumber = user.SerialNumber;
            studentViewModel.Email = email;
            var uf = unitOfWork.UniversityFees.GetUniversityFeeByYear(DateTime.Now);
            if (uf == null)
            {
                ViewBag.Error = $"La période d'immatriculation n'est pas arrivée oubien est passé!";
                return View(model);
            }
            model.Ammount = uf.Ammount;
            model.Model = studentViewModel;

            if (serialNumber != null && ammount != null && email != null)
            {
                var repeatedFee = unitOfWork.StudentFees.Find(s => s.StudentSerialNumber == serialNumber).ToList();
                foreach (var item in repeatedFee)
                {
                    if (item.AccademicYear.ToString("yyyy").Equals(DateTime.Now.ToString("yyyy")))
                    {
                        ViewBag.Error = $"La taxe de l'étudiant dont le matricule est {serialNumber} a déjà été enregistrée pour l'année {item.AccademicYear.ToString("yyyy")}";
                        return View(model);
                    }
                }
                
                float numericAmmount = 0;
                try
                {
                    numericAmmount = float.Parse(ammount);
                    var studentFee = new StudentFee();
                    studentFee.AccademicYear = uf.AcademicYear;
                    studentFee.Ammount = numericAmmount;
                    studentFee.ExpirationDate = uf.ExpirationDate;
                    studentFee.StartDate = uf.StartDate;
                    studentFee.StudentSerialNumber = serialNumber;
                    studentFee.PayementDate = DateTime.Now;
                    studentFee.Email = email;
                    unitOfWork.StudentFees.Add(studentFee);
                    
                    unitOfWork.Complete();
                    ViewBag.Message = $"Taxe enregistrer avec succès";
                    return RedirectToAction();
                }
                catch (Exception)   
                {
                    ViewBag.Error = $"La somme {ammount} doit etre numerique";
                   
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> StudentFeesList(string searchTerm)
        {
            var email = HttpContext.Session.GetString("Email");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            var studentFeeList = unitOfWork.StudentFees.GetAll().ToList();
            var model = new ListStudentPayedFeesViewModel();
            var feeList = new List<StudentPayedFeesViewModel>();

            if (!String.IsNullOrEmpty(searchTerm))
            {
                var serialNumber = searchTerm.Split(":")[1];
                var studentFee = unitOfWork.StudentFees.FindFeeByStudent(serialNumber).ToList();
                if (studentFee.Count != 0)
                {
                    var student = await userManager.FindByEmailAsync(studentFee[0].Email);
                    feeList.Add(new StudentPayedFeesViewModel
                    {
                        Name = student.FirstName + " " + student.LastName,
                        Ammount = studentFee[0].Ammount,
                        DateOfPayment = studentFee[0].PayementDate.ToString("dd/mm/yyyy")
                    });
                    model.Model = feeList;
                    
                    return View(model);
                }

                return View(model);
            }

            foreach (var item in studentFeeList)
            {
                var student = await userManager.FindByEmailAsync(item.Email);
                feeList.Add(new StudentPayedFeesViewModel
                {
                    Name = student.FirstName + " " + student.LastName,
                    Ammount = item.Ammount,
                    DateOfPayment = item.PayementDate.ToString("dd/mm/yyyy")
                });
            }
            model.Model = feeList;

            return View(model);
        }   

        [HttpGet]
        public async Task<JsonResult> AutocompleteStudent(string term)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            var students = unitOfWork.UserStudents.GetStudentByName(term);
            var studentList = new List<string>();

            foreach (var item in students)
            {
                var user = await userManager.FindByEmailAsync(item.Email);
                studentList.Add(user.FirstName + " " + user.LastName + "- MATR:"+user.SerialNumber);
            }
                
            return new JsonResult(studentList);
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public IActionResult UploadVideo(UploadToDollyViewModel model, string serialNumber, string courseCode, string departmentCode)
        {
            var email = HttpContext.Session.GetString("Email");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            model.Dollies = unitOfWork.Dollies.GetDollyByTeacher(serialNumber).ToList();

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.FileToUpload != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "dolly_videos");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + (model.FileToUpload.FileName).Replace(" ", "");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.FileToUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                    DollyVideo dollyVideo = new DollyVideo
                    {
                        FilePath = uniqueFileName,
                        CourseCode = courseCode,
                        TeacherSerialNumber = serialNumber,
                        FileName = model.FileName
                    };
                    unitOfWork.DollyVideos.Add(dollyVideo);
                    unitOfWork.Complete();
                }
                return RedirectToAction("AddToDolly", new { courseCode = courseCode, departmentCode = departmentCode });
            }
            model.DepartmentCode = departmentCode;
            model.CourseCode = courseCode;
            model.TeacherSerialNumber = serialNumber;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> WatchVideo(string path)
        {
            ViewBag.Path = path;
            return View();
        }
    }   
}