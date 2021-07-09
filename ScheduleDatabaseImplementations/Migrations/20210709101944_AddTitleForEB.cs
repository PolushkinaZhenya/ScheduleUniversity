using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleDatabaseImplementations.Migrations
{
    public partial class AddTitleForEB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "EducationalBuildings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "EducationalBuildings");
        }
    }
}
