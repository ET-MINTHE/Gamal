using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class addedalltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Departments_DepartmentCode1",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_DepartmentCode1",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "DepartmentCode1",
                table: "Teachers");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentCode",
                table: "Teachers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_DepartmentCode",
                table: "Teachers",
                column: "DepartmentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Departments_DepartmentCode",
                table: "Teachers",
                column: "DepartmentCode",
                principalTable: "Departments",
                principalColumn: "DepartmentCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Departments_DepartmentCode",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_DepartmentCode",
                table: "Teachers");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentCode",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentCode1",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_DepartmentCode1",
                table: "Teachers",
                column: "DepartmentCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Departments_DepartmentCode1",
                table: "Teachers",
                column: "DepartmentCode1",
                principalTable: "Departments",
                principalColumn: "DepartmentCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
