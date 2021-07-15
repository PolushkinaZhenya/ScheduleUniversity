using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleDatabaseImplementations.Migrations
{
    public partial class Updatelows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HourOfSemesters_Flows_FlowId",
                table: "HourOfSemesters");

            migrationBuilder.DropIndex(
                name: "IX_HourOfSemesters_FlowId",
                table: "HourOfSemesters");

            migrationBuilder.DropColumn(
                name: "FlowId",
                table: "HourOfSemesters");

            migrationBuilder.DropColumn(
                name: "FlowAutoCreation",
                table: "Flows");

            migrationBuilder.AddColumn<Guid>(
                name: "FlowId",
                table: "HourOfSemesterRecords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesterRecords_FlowId",
                table: "HourOfSemesterRecords",
                column: "FlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_HourOfSemesterRecords_Flows_FlowId",
                table: "HourOfSemesterRecords",
                column: "FlowId",
                principalTable: "Flows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HourOfSemesterRecords_Flows_FlowId",
                table: "HourOfSemesterRecords");

            migrationBuilder.DropIndex(
                name: "IX_HourOfSemesterRecords_FlowId",
                table: "HourOfSemesterRecords");

            migrationBuilder.DropColumn(
                name: "FlowId",
                table: "HourOfSemesterRecords");

            migrationBuilder.AddColumn<Guid>(
                name: "FlowId",
                table: "HourOfSemesters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FlowAutoCreation",
                table: "Flows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesters_FlowId",
                table: "HourOfSemesters",
                column: "FlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_HourOfSemesters_Flows_FlowId",
                table: "HourOfSemesters",
                column: "FlowId",
                principalTable: "Flows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
