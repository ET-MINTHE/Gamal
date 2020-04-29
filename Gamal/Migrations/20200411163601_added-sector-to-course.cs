using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class addedsectortocourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Courses");
        }
    }
}
