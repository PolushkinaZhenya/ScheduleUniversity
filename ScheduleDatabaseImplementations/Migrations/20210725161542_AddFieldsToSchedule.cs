using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleDatabaseImplementations.Migrations
{
    public partial class AddFieldsToSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DisciplineId",
                table: "Schedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FlowId",
                table: "Schedules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudyGroupId",
                table: "Schedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "SubgroupNumber",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Schedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TypeOfClassId",
                table: "Schedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DisciplineId",
                table: "Schedules",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_FlowId",
                table: "Schedules",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_StudyGroupId",
                table: "Schedules",
                column: "StudyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TeacherId",
                table: "Schedules",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TypeOfClassId",
                table: "Schedules",
                column: "TypeOfClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Disciplines_DisciplineId",
                table: "Schedules",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Flows_FlowId",
                table: "Schedules",
                column: "FlowId",
                principalTable: "Flows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_StudyGroups_StudyGroupId",
                table: "Schedules",
                column: "StudyGroupId",
                principalTable: "StudyGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Teachers_TeacherId",
                table: "Schedules",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_TypeOfClasses_TypeOfClassId",
                table: "Schedules",
                column: "TypeOfClassId",
                principalTable: "TypeOfClasses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Disciplines_DisciplineId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Flows_FlowId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_StudyGroups_StudyGroupId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Teachers_TeacherId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_TypeOfClasses_TypeOfClassId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_DisciplineId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_FlowId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_StudyGroupId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_TeacherId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_TypeOfClassId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "FlowId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "StudyGroupId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "SubgroupNumber",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TypeOfClassId",
                table: "Schedules");
        }
    }
}
