using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class updatedbooklet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booklets_Students_SerialNumber",
                table: "Booklets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booklets",
                table: "Booklets");

            migrationBuilder.DropIndex(
                name: "IX_Booklets_SerialNumber",
                table: "Booklets");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Booklets");

            migrationBuilder.AddColumn<string>(
                name: "StudentSerialNumber",
                table: "Booklets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeacherSerialNumber",
                table: "Booklets",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booklets",
                table: "Booklets",
                columns: new[] { "CourseCode", "StudentSerialNumber", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_Booklets_StudentSerialNumber",
                table: "Booklets",
                column: "StudentSerialNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Booklets_Students_StudentSerialNumber",
                table: "Booklets",
                column: "StudentSerialNumber",
                principalTable: "Students",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booklets_Students_StudentSerialNumber",
                table: "Booklets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booklets",
                table: "Booklets");

            migrationBuilder.DropIndex(
                name: "IX_Booklets_StudentSerialNumber",
                table: "Booklets");

            migrationBuilder.DropColumn(
                name: "StudentSerialNumber",
                table: "Booklets");

            migrationBuilder.DropColumn(
                name: "TeacherSerialNumber",
                table: "Booklets");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Booklets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booklets",
                table: "Booklets",
                columns: new[] { "CourseCode", "SerialNumber", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_Booklets_SerialNumber",
                table: "Booklets",
                column: "SerialNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Booklets_Students_SerialNumber",
                table: "Booklets",
                column: "SerialNumber",
                principalTable: "Students",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
