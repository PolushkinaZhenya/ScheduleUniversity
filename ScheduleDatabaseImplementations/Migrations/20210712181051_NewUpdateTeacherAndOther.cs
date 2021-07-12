using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleDatabaseImplementations.Migrations
{
    public partial class NewUpdateTeacherAndOther : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumderSubgroups",
                table: "StudyGroups");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "NumderSubgroups",
                table: "StudyGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
