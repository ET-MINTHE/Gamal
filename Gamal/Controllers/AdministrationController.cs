using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using Gamal.Models;
using Gamal.Models.Domain;
using Gamal.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
                var course = unitOfWork.Courses.GetCourseByName(model.Course);
				    if (courseExamSession == null)
				    {
                    courseExamSession = new CourseExamSession { Course = course, CourseCode = course.CourseCode, ExamSession = examSession, ExamSessionId = examSession.ExamSessionId };
                    unitOfWork.CourseExamSessions.Add(courseExamSession);
                    unitOfWork.Complete();
                    courseExamSession = unitOfWork.CourseExamSessions.Find(d => d.ExamSessionId == examSession.ExamSessionId).FirstOrDefault();
                }
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
      [HttpPost]
      public async Task<IActionResult> RemoveExam(int examId)
      {
         var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
         var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
         var course = unitOfWork.Exams.Find(x => x.ExamId == examId).FirstOrDefault();
         unitOfWork.Exams.Remove(course);
         unitOfWork.Complete();
         return RedirectToAction("CallForExam");
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
            model.EnrollmentYear = user.YearOfEnrolement.ToString("yyyy");

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
        public async Task<IActionResult> AddToDolly(string courseCode, string departmentCode, string errorMessage)
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
            if (!String.IsNullOrEmpty(errorMessage))
            {
                ViewBag.Error = errorMessage;
            }
            else
            {
                ViewBag.Error = "";
            }
            
            return View(model);
        }


      [RequestSizeLimit(52428800)]
      public IActionResult AddToDolly(UploadToDollyViewModel model, string courseCode, string departmentCode)
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
         var error = "";
        
         model.Dollies = unitOfWork.Dollies.GetDollyByTeacher(HttpContext.Session.GetString("SerialNumber")).ToList();
			if (model.PDFFileToUpload != null)
			{
            if (model.PDFFileToUpload.ContentType != "application/pdf")
            {
               error = "Only .PDF format is supported for file!";
               return RedirectToAction("AddToDolly", new { courseCode = courseCode, departmentCode = departmentCode, errorMessage = error });
            }
            string uniqueFileName = null;

				string uploadsFolder = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "dolly");
				uniqueFileName = Guid.NewGuid().ToString() + "_" + (model.PDFFileToUpload.FileName).Replace(" ", "");
				string filePath = System.IO.Path.Combine(uploadsFolder, uniqueFileName);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					model.PDFFileToUpload.CopyTo(stream);
					Dolly dolly = new Dolly
					{
						FilePath = uniqueFileName,
						CourseCode = courseCode,
						TeacherSerialNumber = HttpContext.Session.GetString("SerialNumber"),
						FileName = model.PDFFileName
					};

					unitOfWork.Dollies.Add(dolly);
					unitOfWork.Complete();
				}

				return RedirectToAction("AddToDolly", new { courseCode = courseCode, departmentCode = departmentCode });
			}

			ViewBag.Error = "Le nom du fichier PDF et le fichier PDF sont obligatoire!";
			model.DepartmentCode = departmentCode;
			model.CourseCode = courseCode;
			model.TeacherSerialNumber = HttpContext.Session.GetString("SerialNumber");
			model.DollyVideos = unitOfWork.DollyVideos.GetDollyVideoByTeacher(HttpContext.Session.GetString("SerialNumber")).ToList();
			model.Dollies = unitOfWork.Dollies.GetDollyByTeacher(HttpContext.Session.GetString("SerialNumber")).ToList();
			return View(model);
		}

		[HttpPost]
        public async Task<IActionResult> RemoveFromDolly(string id, string courseCode, string departmentCode, string fileType)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
   
            var email = HttpContext.Session.GetString("Email");
            var user = await userManager.FindByEmailAsync(email);

            var model = new UploadToDollyViewModel();

            if (fileType == "pdf")
            {
                var dolly = unitOfWork.Dollies.Get(Int32.Parse(id));
                string uploadsFolder = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "dolly");
                System.IO.File.Delete(System.IO.Path.Combine(uploadsFolder, dolly.FilePath));
                unitOfWork.Dollies.Remove(dolly);
                unitOfWork.Complete();
            }
            else if (fileType == "video")
            {
                var videoDolly = unitOfWork.DollyVideos.Get(Int32.Parse(id));
                string uploadsFolder = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "dolly_videos");
                System.IO.File.Delete(System.IO.Path.Combine(uploadsFolder, videoDolly.FilePath));
                unitOfWork.DollyVideos.Remove(videoDolly);
                unitOfWork.Complete();
            }
           
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
            model.PDFFileName = dolly.FileName;
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
            model.VideoFileName = dolly.FileName;
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

            string uploadsFolder = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "dolly_videos");


            var dolly = unitOfWork.DollyVideos.Get(Int32.Parse(id));

            DollyVideo newDolly = null;

            string oldFileName = dolly.FileName;

            if (model.VideoFileToUpload != null)
            {
                System.IO.File.Delete(System.IO.Path.Combine(uploadsFolder, oldpath));
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + (model.VideoFileToUpload.FileName).Replace(" ", "");
                string filePath = System.IO.Path.Combine(uploadsFolder, uniqueFileName);
                model.VideoFileToUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                newDolly = new DollyVideo
                {
                    FilePath = uniqueFileName,
                    CourseCode = courseCode,
                    TeacherSerialNumber = user.SerialNumber,
                    FileName = model.VideoFileName ?? oldFileName
                };
            }
            else
            {
                newDolly = new DollyVideo
                {
                    CourseCode = dolly.CourseCode,
                    FilePath = dolly.FilePath,
                    FileName = model.VideoFileName ?? dolly.FileName,
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

            string uploadsFolder = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "dolly");
            

            var dolly = unitOfWork.Dollies.Get(Int32.Parse(id));

            Dolly newDolly = null;

            string oldFileName = dolly.FileName;
            
            if (model.PDFFileToUpload != null)
            {
                System.IO.File.Delete(System.IO.Path.Combine(uploadsFolder, oldpath));
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + (model.PDFFileToUpload.FileName).Replace(" ", "");
                string filePath = System.IO.Path.Combine(uploadsFolder, uniqueFileName);
                model.PDFFileToUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                newDolly = new Dolly
                {
                    FilePath = uniqueFileName,
                    CourseCode = courseCode,
                    TeacherSerialNumber = user.SerialNumber,
                    FileName = model.PDFFileName ?? oldFileName
                };
            }
            else
            {
                newDolly = new Dolly
                {
                    CourseCode = dolly.CourseCode,
                    FilePath = dolly.FilePath,
                    FileName = model.PDFFileName ?? dolly.FileName,
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
            if (ModelState.IsValid)
            {
               var studentSerialNumber = "";
               try
               {
                   studentSerialNumber = model.Student.Split(":")[1];
               }
               catch (Exception e)
               {
                  ViewBag.Error = $"Aucun étudiant trouvé avec le matricule {studentSerialNumber}";
                  return View(model);
               }

               var student = unitOfWork.UserStudents.Get(studentSerialNumber);
               if (student == null)
               {
                   ViewBag.Error = $"Aucun étudiant trouvé avec le matricule {studentSerialNumber}";
                   return View(model);
               }
            
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
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            ViewBag.ProfilePath = unitOfWork.Profiles.Find(p => p.SerialNumber == user.SerialNumber).FirstOrDefault().FilePath;
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
                        string uploadsFolder = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "profiles");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileToUpload.FileName;
                        string filePath = System.IO.Path.Combine(uploadsFolder, uniqueFileName);
                        model.FileToUpload.CopyTo(new FileStream(filePath, FileMode.Create));

                        if (oldprofile != null)
                        {
                            if (System.IO.File.Exists(System.IO.Path.Combine(uploadsFolder, oldprofile.FilePath)))
                            {
                                System.IO.File.Delete(System.IO.Path.Combine(uploadsFolder, oldprofile.FilePath));
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
					     else
					     {
                        ViewBag.Error = "Seules les images au format .JPG sont supportées";
                        return View(model);
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
				   try
				   {
                  search = searchTerm.Split(":")[1];
               }
				   catch (Exception)
				   {
                  ViewBag.Error = $"Aucun étudiant trouvé avec ce nom!";
                  return View(model);
				   }
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
            ViewBag.Error = "";
            if (!String.IsNullOrEmpty(searchTerm))
            {
                string serialNumber = null;
                try
				    {
                    serialNumber = searchTerm.Split(":")[1];
                }
				    catch (Exception)
				    {
                   ViewBag.Error = "Une erreur est survenue";
                   return View(model);
				    }
                
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
      [RequestSizeLimit(52428800)]
      [RequestFormLimits(MultipartBodyLengthLimit = 52428800)]
      public IActionResult UploadVideo(UploadToDollyViewModel model, string serialNumber, string courseCode, string departmentCode)
        {
            var email = HttpContext.Session.GetString("Email");
            var error = "";
			   if (model.VideoFileToUpload.ContentType != "video/mp4")
			   {
                error = "Only .mp4 format is supported for video!";
               return RedirectToAction("AddToDolly", new { courseCode = courseCode, departmentCode = departmentCode, errorMessage = error });
            }
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            model.Dollies = unitOfWork.Dollies.GetDollyByTeacher(serialNumber).ToList();

            if (model.VideoFileToUpload != null)
            {
                string uniqueFileName = null;
                string uploadsFolder = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "dolly_videos");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + (model.VideoFileToUpload.FileName).Replace(" ", "");
                string filePath = System.IO.Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.VideoFileToUpload.CopyTo(stream);
                    DollyVideo dollyVideo = new DollyVideo
                    {
                        FilePath = uniqueFileName,
                        CourseCode = courseCode,
                        TeacherSerialNumber = HttpContext.Session.GetString("SerialNumber"),
                        FileName = model.VideoFileName
                    };
                    unitOfWork.DollyVideos.Add(dollyVideo);
                    unitOfWork.Complete();
                }
               
                return RedirectToAction("AddToDolly", new { courseCode = courseCode, departmentCode = departmentCode });
            }
            error = "Le nom de la Vidéo et la Video sont obligatoire!";
            return RedirectToAction("AddToDolly", new { courseCode = courseCode, departmentCode = departmentCode, errorMessage = error });
        }

        [HttpGet]
        public async Task<IActionResult> WatchVideo(string path)
        {
            ViewBag.Path = path;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EnrollmentCertificate()
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
            ViewBag.message = "";
            ViewBag.error = "";
            if (!String.IsNullOrEmpty(TempData["message"]?.ToString()))
            {
                ViewBag.message = TempData["message"]?.ToString();
                TempData["message"] = "";
            }
            if (!String.IsNullOrEmpty(TempData["error"]?.ToString()))
            {
               ViewBag.error = TempData["error"]?.ToString();
               TempData["error"] = "";
            }
           return View();
        }

        [HttpGet]
        public IActionResult EnrollmentCertificateView(StudentCertificateViewModel model)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            var email = HttpContext.Session.GetString("Email");
			   if(!ModelState.IsValid)
			   {
                TempData["error"] = "Le nom ou le matricule de l'étudiant est obligatoire";
                return RedirectToAction("EnrollmentCertificate");
            }
            string studentSerialNumber = "";

            try
			   {
                studentSerialNumber = model.Student.Split(":")[1];
            }
			   catch (Exception)
			   {
               TempData["error"] = "Numero de matricule ou nom invalide";
               return RedirectToAction("EnrollmentCertificate");
			   }
            
            var student = unitOfWork.UserStudents.Get(studentSerialNumber);
            if (student == null)
            {
                ViewBag.Error = $"Aucun étudiant trouvé avec le matricule {studentSerialNumber}";
                return RedirectToAction("EnrollmentCertificate");
            }

            var studentInfo = unitOfWork.UserStudents.GetStudentBySerialNumber(studentSerialNumber).First();
            var studentUserInfo = userManager.FindByEmailAsync(studentInfo.Email).GetAwaiter().GetResult();

            Document document = new Document();

            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            Label univLabel = new Label("UNIVERSITE GAMAL ADBED NASSER DE CONAKRY", 0, 0, 504, 100, Font.Helvetica, 15, TextAlign.Center);
            page.Elements.Add(univLabel);   
          
            Label facLabel = new Label(studentUserInfo.Faculty, 0, 60, 504, 100, Font.Helvetica, 13, TextAlign.Center);
            page.Elements.Add(facLabel);

            var newYear = studentUserInfo.YearOfEnrolement.AddYears(1);
            string certificate = "CERTIFICAT D'INSCRIPTION ANNEE ACADEMIQUE " + studentUserInfo.YearOfEnrolement.ToString("yyyy")+ "/"+newYear.ToString("yyyy");
            Label certificateLabel = new Label(certificate, 0, 120, 504, 100, Font.Helvetica, 12, TextAlign.Center);
            page.Elements.Add(certificateLabel);

            string certificateHeader = $"Le directeur de l' {studentUserInfo.Faculty.ToLower()} de l'Université Gamal Abdel Nasser de Conakry, soussigné, atteste que:";
            Label certificateHeaderLabel = new Label(certificateHeader, 0, 180, 504, 500, Font.HelveticaBold, 12, TextAlign.Left);
            page.Elements.Add(certificateHeaderLabel);

            string studentName = $"L'Etudiant:  {studentUserInfo.FirstName} {studentUserInfo.LastName}";
            Label studentNameLabel = new Label(studentName, 0, 225, 504, 500, Font.Helvetica, 12, TextAlign.Left);
            page.Elements.Add(studentNameLabel);

            string serialNumber = $"N° Matricule:  {studentUserInfo.SerialNumber}";
            Label serialNumberLabel = new Label(serialNumber, 0, 255, 504, 500, Font.Helvetica, 12, TextAlign.Left);
            page.Elements.Add(serialNumberLabel);

            string department = $"est régulièrement inscrit en {studentUserInfo.CurrentYear}° année au département de {char.ToUpper(studentUserInfo.Department[0]) + studentUserInfo.Department.Substring(1).ToLower()}";
            Label departmentLabel = new Label(department, 0, 285, 504, 500, Font.Helvetica, 12, TextAlign.Left);
            page.Elements.Add(departmentLabel);

            string certification = $"En foi de quoi, la présente ATTESTATION lui est délivrée pour servir et valoir ce que de droit";
            Label certificationLabel = new Label(certification, 0, 330, 504, 500, Font.Helvetica, 12, TextAlign.Left);
            page.Elements.Add(certificationLabel);

            string dateAndPlace = $"Conakry,  le {DateTime.Now.ToString("dd/MM/yyyy")}";
            Label dateAndPlaceLabel = new Label(dateAndPlace, 0, 370, 504, 500, Font.Helvetica, 12, TextAlign.Right);
            page.Elements.Add(dateAndPlaceLabel);

            string headOfDepartment = $"Le Chef de Département";
            Label headOfDepartmentLabel = new Label(headOfDepartment, 0, 450, 504, 500, Font.Helvetica, 10, TextAlign.Left);
            page.Elements.Add(headOfDepartmentLabel);

            string headOfFacultyStudy = $"Le Directeur Géneral Adjoint Chargé des Etudes";
            Label headOfFacultyStudyLabel = new Label(headOfFacultyStudy, 0, 450, 504, 500, Font.Helvetica, 10, TextAlign.Center);
            page.Elements.Add(headOfFacultyStudyLabel);

            string headOfFaculty = $"Le Directeur Géneral";
            Label headOfFacultyLabel = new Label(headOfFaculty, 0, 450, 504, 500, Font.Helvetica, 10, TextAlign.Right);
            page.Elements.Add(headOfFacultyLabel);

            HeaderFooterTemplate header = new HeaderFooterTemplate("", "NB: Ce document ne doit comporter ni ratures ni surcharges.");
            document.Template = header;
            document.Draw("output.pdf");
            var stream = new FileStream(@"output.pdf", FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }

        [HttpGet]
        public async Task<IActionResult> TeacherBookingBoard(string? subject)
        {
         //tableau de reservation
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
            
            HttpContext.Session.Get("SerialNumber");
            var serialNumber = HttpContext.Session.GetString("SerialNumber");
            var result1 = unitOfWork.Teachers.GetExamByTeacher(serialNumber);
            List<string> subjects = new List<string>();
            foreach (var item in result1)
            {
               subjects.Add(item.Name);
            }
            ViewBag.subjects = subjects;
			   
			   if(subject != null)
			   {
                var result = unitOfWork.ExamEnrollments.GetStudentEnrollmentBySubject(subject).ToList();
                List<string> res = new List<string>();
				   foreach (var item in result)
				   {
                  res.AddRange(item.ExamEnrollments.Select(x => x.SerialNumber).ToList());
				   }
                 
               var user = userManager.Users.Where(x => res.Contains(x.SerialNumber)).ToList();
               
               ViewBag.studentList = user;
            }
         return View();
      }  
    }   
}