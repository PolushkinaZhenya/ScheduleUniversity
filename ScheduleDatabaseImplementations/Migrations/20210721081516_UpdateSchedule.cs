using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleDatabaseImplementations.Migrations
{
    public partial class UpdateSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Periods_PeriodId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_StudyGroups_StudyGroupId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Teachers_TeacherId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_StudyGroupId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_TeacherId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "StudyGroupId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Subgroups",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "PeriodId",
                table: "Schedules",
                newName: "HourOfSemesterPeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_PeriodId",
                table: "Schedules",
                newName: "IX_Schedules_HourOfSemesterPeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_HourOfSemesterPeriods_HourOfSemesterPeriodId",
                table: "Schedules",
                column: "HourOfSemesterPeriodId",
                principalTable: "HourOfSemesterPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_HourOfSemesterPeriods_HourOfSemesterPeriodId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "HourOfSemesterPeriodId",
                table: "Schedules",
                newName: "PeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_HourOfSemesterPeriodId",
                table: "Schedules",
                newName: "IX_Schedules_PeriodId");

            migrationBuilder.AddColumn<Guid>(
                name: "StudyGroupId",
                table: "Schedules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Subgroups",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Schedules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_StudyGroupId",
                table: "Schedules",
                column: "StudyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TeacherId",
                table: "Schedules",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Periods_PeriodId",
                table: "Schedules",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_StudyGroups_StudyGroupId",
                table: "Schedules",
                column: "StudyGroupId",
                principalTable: "StudyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Teachers_TeacherId",
                table: "Schedules",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
