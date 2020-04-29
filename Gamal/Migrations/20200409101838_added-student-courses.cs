using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class addedstudentcourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Courses_CourseCode",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Students_UserStudentSerialNumber",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserStudentSerialNumber",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CourseCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserStudentSerialNumber",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "CourseUserStudents",
                columns: table => new
                {
                    CourseCode = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUserStudents", x => new { x.CourseCode, x.SerialNumber });
                    table.ForeignKey(
                        name: "FK_CourseUserStudents_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseUserStudents_Students_SerialNumber",
                        column: x => x.SerialNumber,
                        principalTable: "Students",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseUserStudents_SerialNumber",
                table: "CourseUserStudents",
                column: "SerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseUserStudents");

            migrationBuilder.AddColumn<string>(
                name: "UserStudentSerialNumber",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserStudentSerialNumber",
                table: "Courses",
                column: "UserStudentSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CourseCode",
                table: "AspNetUsers",
                column: "CourseCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Courses_CourseCode",
                table: "AspNetUsers",
                column: "CourseCode",
                principalTable: "Courses",
                principalColumn: "CourseCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Students_UserStudentSerialNumber",
                table: "Courses",
                column: "UserStudentSerialNumber",
                principalTable: "Students",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
