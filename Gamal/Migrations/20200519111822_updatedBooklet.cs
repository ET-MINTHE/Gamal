using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class updatedBooklet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Booklets",
                table: "Booklets");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherSerialNumber",
                table: "Booklets",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booklets",
                table: "Booklets",
                columns: new[] { "CourseCode", "StudentSerialNumber", "TeacherSerialNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Booklets",
                table: "Booklets");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherSerialNumber",
                table: "Booklets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booklets",
                table: "Booklets",
                columns: new[] { "CourseCode", "StudentSerialNumber", "Date" });
        }
    }
}
