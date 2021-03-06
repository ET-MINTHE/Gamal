﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamal.Migrations
{
    public partial class addedlengthtocourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "Courses");
        }
    }
}
