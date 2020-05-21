using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class addstudentFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentFees",
                columns: table => new
                {
                    StudentSerialNumber = table.Column<string>(nullable: false),
                    AccademicYear = table.Column<DateTime>(nullable: false),
                    UserStudentSerialNumber = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    PayementDate = table.Column<DateTime>(nullable: false),
                    Ammount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFees", x => new { x.AccademicYear, x.StudentSerialNumber });
                    table.ForeignKey(
                        name: "FK_StudentFees_Students_UserStudentSerialNumber",
                        column: x => x.UserStudentSerialNumber,
                        principalTable: "Students",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentFees_UserStudentSerialNumber",
                table: "StudentFees",
                column: "UserStudentSerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentFees");
        }
    }
}
