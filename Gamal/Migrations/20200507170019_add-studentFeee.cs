using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class addstudentFeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentFees_Students_UserStudentSerialNumber",
                table: "StudentFees");

            migrationBuilder.DropIndex(
                name: "IX_StudentFees_UserStudentSerialNumber",
                table: "StudentFees");

            migrationBuilder.DropColumn(
                name: "UserStudentSerialNumber",
                table: "StudentFees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserStudentSerialNumber",
                table: "StudentFees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentFees_UserStudentSerialNumber",
                table: "StudentFees",
                column: "UserStudentSerialNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFees_Students_UserStudentSerialNumber",
                table: "StudentFees",
                column: "UserStudentSerialNumber",
                principalTable: "Students",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
