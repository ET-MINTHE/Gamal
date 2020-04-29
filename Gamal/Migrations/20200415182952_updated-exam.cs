using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class updatedexam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classroom",
                table: "ExamEnrollments");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ExamEnrollments");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "ExamEnrollments");

            migrationBuilder.AddColumn<string>(
                name: "Classroom",
                table: "Exams",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Hour",
                table: "Exams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classroom",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Exams");

            migrationBuilder.AddColumn<string>(
                name: "Classroom",
                table: "ExamEnrollments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ExamEnrollments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Hour",
                table: "ExamEnrollments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
