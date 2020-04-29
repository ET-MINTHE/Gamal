using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class addedbooklet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booklets",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    CourseCode = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false),
                    Mark = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booklets", x => new { x.CourseCode, x.SerialNumber, x.Date });
                    table.ForeignKey(
                        name: "FK_Booklets_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booklets_Students_SerialNumber",
                        column: x => x.SerialNumber,
                        principalTable: "Students",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booklets_SerialNumber",
                table: "Booklets",
                column: "SerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booklets");
        }
    }
}
