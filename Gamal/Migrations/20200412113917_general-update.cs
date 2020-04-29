using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class generalupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PartTime",
                table: "Students",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Profile",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseType",
                table: "Departments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartTime",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Profile",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseType",
                table: "Departments");
        }
    }
}
