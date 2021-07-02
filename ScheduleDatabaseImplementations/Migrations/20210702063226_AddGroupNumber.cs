using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleDatabaseImplementations.Migrations
{
    public partial class AddGroupNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupNumber",
                table: "StudyGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupNumber",
                table: "StudyGroups");
        }
    }
}
