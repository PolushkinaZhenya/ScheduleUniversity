using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleDatabaseImplementations.Migrations
{
    public partial class ChangeTotalHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "HourOfSemesterPeriods");

            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "HourOfSemesterRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "HourOfSemesterRecords");

            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "HourOfSemesterPeriods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
