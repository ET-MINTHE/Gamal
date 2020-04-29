using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class addedalltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentCode",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CourseUserStudents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mark",
                table: "CourseUserStudents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportDate",
                table: "CourseUserStudents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExamSessions",
                columns: table => new
                {
                    ExamSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSessions", x => x.ExamSessionId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Office = table.Column<string>(nullable: true),
                    DepartmentCode = table.Column<string>(nullable: true),
                    DepartmentCode1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Teachers_Departments_DepartmentCode1",
                        column: x => x.DepartmentCode1,
                        principalTable: "Departments",
                        principalColumn: "DepartmentCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseExamSessions",
                columns: table => new
                {
                    CourseExamSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(nullable: true),
                    ExamSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseExamSessions", x => x.CourseExamSessionId);
                    table.ForeignKey(
                        name: "FK_CourseExamSessions_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseExamSessions_ExamSessions_ExamSessionId",
                        column: x => x.ExamSessionId,
                        principalTable: "ExamSessions",
                        principalColumn: "ExamSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTeacherCourses",
                columns: table => new
                {
                    CourseCode = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeacherCourses", x => new { x.CourseCode, x.SerialNumber });
                    table.ForeignKey(
                        name: "FK_UserTeacherCourses_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTeacherCourses_Teachers_SerialNumber",
                        column: x => x.SerialNumber,
                        principalTable: "Teachers",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Hour = table.Column<string>(nullable: true),
                    Classroom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CourseExamSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Exams_CourseExamSessions_CourseExamSessionId",
                        column: x => x.CourseExamSessionId,
                        principalTable: "CourseExamSessions",
                        principalColumn: "CourseExamSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamEnrollments",
                columns: table => new
                {
                    ExamEnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    ExamId = table.Column<int>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamEnrollments", x => x.ExamEnrollmentId);
                    table.ForeignKey(
                        name: "FK_ExamEnrollments_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamEnrollments_Students_SerialNumber",
                        column: x => x.SerialNumber,
                        principalTable: "Students",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentCode",
                table: "Students",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExamSessions_CourseCode",
                table: "CourseExamSessions",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExamSessions_ExamSessionId",
                table: "CourseExamSessions",
                column: "ExamSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamEnrollments_ExamId",
                table: "ExamEnrollments",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamEnrollments_SerialNumber",
                table: "ExamEnrollments",
                column: "SerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CourseExamSessionId",
                table: "Exams",
                column: "CourseExamSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_DepartmentCode1",
                table: "Teachers",
                column: "DepartmentCode1");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeacherCourses_SerialNumber",
                table: "UserTeacherCourses",
                column: "SerialNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentCode",
                table: "Students",
                column: "DepartmentCode",
                principalTable: "Departments",
                principalColumn: "DepartmentCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentCode",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ExamEnrollments");

            migrationBuilder.DropTable(
                name: "UserTeacherCourses");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "CourseExamSessions");

            migrationBuilder.DropTable(
                name: "ExamSessions");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentCode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CourseUserStudents");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "CourseUserStudents");

            migrationBuilder.DropColumn(
                name: "ReportDate",
                table: "CourseUserStudents");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Courses");
        }
    }
}
