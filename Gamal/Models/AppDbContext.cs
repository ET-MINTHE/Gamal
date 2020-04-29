using Gamal.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserStudent> Students { get; set; }
        public DbSet<CourseUserStudent> CourseUserStudents { get; set; }
        public DbSet<UserTeacher> Teachers { get; set; }    
        public DbSet<UserTeacherCourse> UserTeacherCourses { get; set;  }
        public DbSet<ExamSession> ExamSessions { get; set; }    
        public DbSet<CourseExamSession> CourseExamSessions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamEnrollment> ExamEnrollments { get; set; }
        public DbSet<Booklet> Booklets { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Dolly> Dollies { get; set; }
            
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("Connection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set primary key of the bridge table between student and course
            modelBuilder.Entity<CourseUserStudent>()
               .HasKey(cs => new { cs.CourseCode, cs.SerialNumber });

            modelBuilder.Entity<CourseUserStudent>()
                .HasOne(c => c.Course)
                .WithMany(cs => cs.CourseUserStudents)
                .HasForeignKey(cs => cs.CourseCode);

            modelBuilder.Entity<CourseUserStudent>()
                .HasOne(c => c.UserStudent)
                .WithMany(cs => cs.CourseUserStudents)
                .HasForeignKey(cs => cs.SerialNumber);

            modelBuilder.Entity<UserTeacherCourse>()
               .HasKey(utc => new { utc.CourseCode, utc.SerialNumber});

            modelBuilder.Entity<UserTeacherCourse>()
                .HasOne(u => u.UserTeacher)
                .WithMany(ut => ut.UserTeacherCourses)
                .HasForeignKey(utd => utd.SerialNumber);

            modelBuilder.Entity<UserTeacherCourse>()
                .HasOne(u => u.Course)
                .WithMany(utd => utd.UserTeacherCourses)
                .HasForeignKey(ut => ut.CourseCode);

            //modelBuilder.Entity<ExamSession>()
            //   .HasKey(es => new { es.Start, es.End });

            //modelBuilder.Entity<CourseExamSession>()
            //   .HasKey(ces => new { ces.Start, ces.End, ces.CourseCode});

            modelBuilder.Entity<CourseExamSession>()
                .HasOne(c => c.ExamSession)
                .WithMany(ce => ce.CourseExamSessions)
                .HasForeignKey(ce => ce.ExamSessionId);

            modelBuilder.Entity<CourseExamSession>()
                .HasOne(c => c.Course)
                .WithMany(cc => cc.CourseExamSessions)
                .HasForeignKey(cc => cc.CourseCode);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(cd => cd.Courses)
                .HasForeignKey(cd => cd.DepartmentCode);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Faculty)
                .WithMany(df => df.Departments)
                .HasForeignKey(df => df.FacultyCode);

            modelBuilder.Entity<UserStudent>()
                .HasOne(us => us.Department)
                .WithMany(df => df.UserStudents)
                .HasForeignKey(df => df.DepartmentCode);

            modelBuilder.Entity<Exam>()
                .HasOne(ces => ces.CourseExamSession)
                .WithMany(e => e.Exams)
                .HasForeignKey(e => e.CourseExamSessionId);

            modelBuilder.Entity<ExamEnrollment>()
                .HasOne(e => e.Exam)
                .WithMany(ee => ee.ExamEnrollments)
                .HasForeignKey(ee => ee.ExamId);

            modelBuilder.Entity<ExamEnrollment>()
                .HasOne(e => e.UserStudent)
                .WithMany(ee => ee.ExamEnrollments)
                .HasForeignKey(ee => ee.SerialNumber);

            modelBuilder.Entity<UserTeacher>()
                .HasOne(ut => ut.Department)
                .WithMany(ud => ud.UserTeachers)
                .HasForeignKey(ud => ud.DepartmentCode);

            modelBuilder.Entity<Booklet>()
               .HasKey(b => new { b.CourseCode, b.StudentSerialNumber, b.Date});

            modelBuilder.Entity<Booklet>()
                .HasOne(b => b.UserStudent)
                .WithMany(us => us.Booklets)
                .HasForeignKey(us => us.StudentSerialNumber);

            modelBuilder.Entity<Booklet>()
                .HasOne(b => b.Course)
                .WithMany(c => c.Booklets)
                .HasForeignKey(c => c.CourseCode);

            base.OnModelCreating(modelBuilder);
        }
    }
}
