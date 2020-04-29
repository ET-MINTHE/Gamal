using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamal.Models;
using Gamal.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gamal.Controllers
{
    public class PopulateDatabaseController : Controller
    {
        public IActionResult Index()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));

            var faculty1 = new Faculty() { FacultyName = "INSTITUT POLYTECHNIQUE", FacultyCode = "IPC" };
            var faculty2 = new Faculty() { FacultyName = "FACULTE DES SCIENCE", FacultyCode = "FDS" };
            
            var department11 = new Department()
            {
                DepartmentCode = "GINF",
                DepartmentName = "GENIE INFORMATIQUE",
                Faculty = faculty1,
                CourseType = "COURS ABOUTISSANT A UN DIPLOME D'INGENIEUR"
            };

            var department12 = new Department()
            {
                DepartmentCode = "TELECOMS",
                DepartmentName = "TELECOMMUNICATIONS",
                Faculty = faculty1,
                CourseType = "COURS ABOUTISSANT A UN DIPLOME D'INGENIEUR"
            };

            var department13 = new Department()
            {
                DepartmentCode = "GEL",
                DepartmentName = "GENIE ELECTRIQUE",
                Faculty = faculty1,
                CourseType = "COURS ABOUTISSANT A UN DIPLOME D'INGENIEUR"
            };

            var course1 = new Course()
            {
                CourseCode = "AM1",
                CourseName = "ANALYSE MATHEMATIQUE 1",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 1,
                Description = "Activité didactique liée au plan",
                Sector = "Mathematiques"
            };

            var course2 = new Course()
            {
                CourseCode = "AM2",
                CourseName = "ANALYSE MATHEMATIQUE 2",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 1,
                Description = "Activité didactique liée au plan",
                Sector = "Mathematiques"
            };

            var course3 = new Course()
            {
                CourseCode = "FD1",
                CourseName = "FONDEMENT D INFORMATIQUE 1 E LAB",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 1,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMATIQUE"
            };

            var course4 = new Course()
            {
                CourseCode = "FD2",
                CourseName = "FONDEMENT D INFORMATIQUE 2 E LAB",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 1,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMATIQUE"
            };
                
            var course5 = new Course()
            {
                CourseCode = "AD",
                CourseName = "ARCHITECTURE DES ORDINATEUR",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 1,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMATIQUE"
            };
                
            var course6 = new Course()
            {
                CourseCode = "FE",
                CourseName = "FONDEMENT DE ELECTRONIQUE",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 2,
                Description = "Activité didactique liée au plan",
                Sector = "ELECTRONIQUE"
            };

            var course7 = new Course()  
            {
                CourseCode = "FT",
                CourseName = "FONDEMENT DE TELECOMMUNICATION",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 3,
                Description = "Activité didactique liée au plan",
                Sector = "TELECOMMUNICATIONS"
            };

            var course8 = new Course()
            {
                CourseCode = "PHY",
                CourseName = "PHYSIQUE",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 12,
                Length = 90,
                Year = 1,
                Description = "Activité didactique liée au plan",
                Sector = "PHYSIQUE"
            };

            var course9 = new Course()
            {
                CourseCode = "GEO",
                CourseName = "GEOMETRIE",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 12,
                Length = 90,
                Year = 1,
                Description = "Activité didactique liée au plan",
                Sector = "MATHEMATIQUE"
            };
                
            var course10 = new Course()
            {
                CourseCode = "ANG",
                CourseName = "ANGLAIS",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 12,
                Length = 90,
                Year = 1,
                Description = "Activité didactique liée au plan",
                Sector = "LANGUES"
            };
                
            var course11 = new Course()
            {
                CourseCode = "MAS",
                CourseName = "MATHEMATIQUES APPLIQUES ET STATISTIQUE",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 6,
                Length = 50,
                Year = 1,
                Description = "Activité didactique liée au plan",
                Sector = "MATHEMATIQUE"
            };

            var course12  = new Course()
            {
                CourseCode = "DB",
                CourseName = "BASE DE DONNEE ET LAB",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 60,
                Year = 2,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMATIQUE"
            };

            var course13 = new Course()
            {
                CourseCode = "SE",
                CourseName = "SYSTEME D'EXPLOITATION ET LAB",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 60,
                Year = 2,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMATIQUE"
            };

            var course14 = new Course()
            {   
                CourseCode = "II",
                CourseName = "INFORMATIQUE INDUSTRIELLE",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 60,
                Year = 3,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMATIQUE"
            };

            var course15 = new Course()
            {
                CourseCode = "CE",
                CourseName = "CIRCUIT ELECTRIQUE",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 60,
                Year = 2,
                Description = "Activité didactique liée au plan",
                Sector = "ELECTRONIQUE"
            };

            var course16 = new Course()
            {
                CourseCode = "RO",
                CourseName = "RESEAUX D'ORDINATEUR ET LAB",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 60,
                Year = 3,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMATIQUE"
            };

            var course17 = new Course()
            {
                CourseCode = "IL",
                CourseName = "INGENIERIE ET LAB",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 60,
                Year = 3,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMATIQUE"
            };

            var course18 = new Course()
            {
                CourseCode = "CA",
                CourseName = "CONTROLE AUTOMATIQUE",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 60,
                Year = 2,
                Description = "Activité didactique liée au plan",
                Sector = "ELECTRONIQUE"
            };

            var course19 = new Course()
            {
                CourseCode = "BDA",
                CourseName = "BIG DATA ANALYSIS",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 60,
                Year = 4,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMQTIQUE"
            };

            var course20 = new Course()
            {
                CourseCode = "MD",
                CourseName = "MATHEMATIQUE DISCRETE",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 6,
                Length = 60,
                Year = 4,
                Description = "Activité didactique liée au plan",
                Sector = "MATHEMATIQUE"
            };

            var course21 = new Course()
            {
                CourseCode = "PRML",
                CourseName = "PATTERN RECOGNITION ET MACHINE LEARNING",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 4,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMQTIQUE"
            };

            var course22 = new Course()
            {
                CourseCode = "CSE", 
                CourseName = "CONCEPTION DES SYSTEMES D'EXPLOITATION",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 4,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMQTIQUE"
            };

            var course23 = new Course()
            {
                CourseCode = "CL",
                CourseName = "CONCEPTION DES LOGICIELS",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 4,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMQTIQUE"
            };

            var course24 = new Course()
            {
                CourseCode = "SAR",
                CourseName = "SYSTEMES ET APPLICATIONS DE RESEAUX",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 5,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMQTIQUE"
            };

            var course25 = new Course()
            {
                CourseCode = "TBD",
                CourseName = "TECHNOLOGIES DES BASE DE DONNEES",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 5,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMQTIQUE"
            };

            var course26 = new Course()
            {
                CourseCode = "TIR",
                CourseName = "TECHOLOGIES DES INFRASTRUCTURES DES RESEAUX",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 5,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMQTIQUE"
            };

            var course27 = new Course()
            {
                CourseCode = "TSC",
                CourseName = "THEORIES DES SYSTEMES ET DU CONTROLE",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 5,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMQTIQUE"
            };

            var course28 = new Course()
            {   
                CourseCode = "LII",
                CourseName = "LABORATOIRE D'INGENIERIE INFORMQTIQUE",
                Department = department11,
                Teacher = null,
                Faculty = faculty1,
                Weight = 9,
                Length = 90,
                Year = 5,
                Description = "Activité didactique liée au plan",
                Sector = "INFORMQTIQUE"
            };
            unitOfWork.Faculties.Add(faculty1);
            unitOfWork.Faculties.Add(faculty2);
           
            unitOfWork.Departments.Add(department11);
            unitOfWork.Departments.Add(department12);

            unitOfWork.Courses.Add(course1);
            unitOfWork.Courses.Add(course2);
            unitOfWork.Courses.Add(course3);
            unitOfWork.Courses.Add(course4);
            unitOfWork.Courses.Add(course5);
            unitOfWork.Courses.Add(course6);
            unitOfWork.Courses.Add(course7);
            unitOfWork.Courses.Add(course8);
            unitOfWork.Courses.Add(course9);
            unitOfWork.Courses.Add(course10);
            unitOfWork.Courses.Add(course11);
            unitOfWork.Courses.Add(course12);
            unitOfWork.Courses.Add(course13);
            unitOfWork.Courses.Add(course14);
            unitOfWork.Courses.Add(course15);
            unitOfWork.Courses.Add(course16);
            unitOfWork.Courses.Add(course17);
            unitOfWork.Courses.Add(course18);
            unitOfWork.Courses.Add(course19);
            unitOfWork.Courses.Add(course20);

            unitOfWork.Courses.Add(course21);
            unitOfWork.Courses.Add(course22);
            unitOfWork.Courses.Add(course23);
            unitOfWork.Courses.Add(course24);
            unitOfWork.Courses.Add(course25);
            unitOfWork.Courses.Add(course26);

            unitOfWork.Courses.Add(course27);
            unitOfWork.Courses.Add(course28);
          
            unitOfWork.Complete();
            return View();
        }
    }
}