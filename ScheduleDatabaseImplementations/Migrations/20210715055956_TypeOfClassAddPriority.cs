﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleDatabaseImplementations.Migrations
{
    public partial class TypeOfClassAddPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "TypeOfClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "TypeOfClasses");
        }
    }
}
