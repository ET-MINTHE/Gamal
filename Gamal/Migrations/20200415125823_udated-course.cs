using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class udatedcourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "TeacherSerialNumber",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherSerialNumber",
                table: "Courses",
                column: "TeacherSerialNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherSerialNumber",
                table: "Courses",
                column: "TeacherSerialNumber",
                principalTable: "Teachers",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherSerialNumber",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherSerialNumber",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TeacherSerialNumber",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
