using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class addedstudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserStudentSerialNumber",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.SerialNumber);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Courses_CourseCode",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Students_UserStudentSerialNumber",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

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

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "AspNetUsers");
        }
    }
}
