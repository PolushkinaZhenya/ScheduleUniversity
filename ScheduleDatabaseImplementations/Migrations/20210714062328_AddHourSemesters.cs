using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleDatabaseImplementations.Migrations
{
    public partial class AddHourSemesters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_LoadTeachers_LoadTeacherId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "LoadTeacherAuditoriums");

            migrationBuilder.DropTable(
                name: "LoadTeacherPeriods");

            migrationBuilder.DropTable(
                name: "LoadTeachers");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_LoadTeacherId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "LoadTeacherId",
                table: "Schedules");

            migrationBuilder.CreateTable(
                name: "HourOfSemesters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisciplineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Reporting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wishes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourOfSemesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourOfSemesters_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HourOfSemesters_Flows_FlowId",
                        column: x => x.FlowId,
                        principalTable: "Flows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HourOfSemesters_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HourOfSemesters_StudyGroups_StudyGroupId",
                        column: x => x.StudyGroupId,
                        principalTable: "StudyGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HourOfSemesterRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HourOfSemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubgroupNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourOfSemesterRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourOfSemesterRecords_HourOfSemesters_HourOfSemesterId",
                        column: x => x.HourOfSemesterId,
                        principalTable: "HourOfSemesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HourOfSemesterRecords_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HourOfSemesterRecords_TypeOfClasses_TypeOfClassId",
                        column: x => x.TypeOfClassId,
                        principalTable: "TypeOfClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HourOfSemesterAuditoriums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HourOfSemesterRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditoriumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourOfSemesterAuditoriums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourOfSemesterAuditoriums_Auditoriums_AuditoriumId",
                        column: x => x.AuditoriumId,
                        principalTable: "Auditoriums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HourOfSemesterAuditoriums_HourOfSemesterRecords_HourOfSemesterRecordId",
                        column: x => x.HourOfSemesterRecordId,
                        principalTable: "HourOfSemesterRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HourOfSemesterPeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HourOfSemesterRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: false),
                    HoursFirstWeek = table.Column<int>(type: "int", nullable: false),
                    HoursSecondWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourOfSemesterPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourOfSemesterPeriods_HourOfSemesterRecords_HourOfSemesterRecordId",
                        column: x => x.HourOfSemesterRecordId,
                        principalTable: "HourOfSemesterRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HourOfSemesterPeriods_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesterAuditoriums_AuditoriumId",
                table: "HourOfSemesterAuditoriums",
                column: "AuditoriumId");

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesterAuditoriums_HourOfSemesterRecordId",
                table: "HourOfSemesterAuditoriums",
                column: "HourOfSemesterRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesterPeriods_HourOfSemesterRecordId",
                table: "HourOfSemesterPeriods",
                column: "HourOfSemesterRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesterPeriods_PeriodId",
                table: "HourOfSemesterPeriods",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesterRecords_HourOfSemesterId",
                table: "HourOfSemesterRecords",
                column: "HourOfSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesterRecords_TeacherId",
                table: "HourOfSemesterRecords",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesterRecords_TypeOfClassId",
                table: "HourOfSemesterRecords",
                column: "TypeOfClassId");

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesters_DisciplineId",
                table: "HourOfSemesters",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesters_FlowId",
                table: "HourOfSemesters",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesters_SemesterId",
                table: "HourOfSemesters",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_HourOfSemesters_StudyGroupId",
                table: "HourOfSemesters",
                column: "StudyGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourOfSemesterAuditoriums");

            migrationBuilder.DropTable(
                name: "HourOfSemesterPeriods");

            migrationBuilder.DropTable(
                name: "HourOfSemesterRecords");

            migrationBuilder.DropTable(
                name: "HourOfSemesters");

            migrationBuilder.AddColumn<Guid>(
                name: "LoadTeacherId",
                table: "Schedules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoadTeachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisciplineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfSubgroups = table.Column<int>(type: "int", nullable: true),
                    Reporting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadTeachers_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadTeachers_Flows_FlowId",
                        column: x => x.FlowId,
                        principalTable: "Flows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadTeachers_TypeOfClasses_TypeOfClassId",
                        column: x => x.TypeOfClassId,
                        principalTable: "TypeOfClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoadTeacherAuditoriums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditoriumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoadTeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadTeacherAuditoriums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadTeacherAuditoriums_Auditoriums_AuditoriumId",
                        column: x => x.AuditoriumId,
                        principalTable: "Auditoriums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadTeacherAuditoriums_LoadTeachers_LoadTeacherId",
                        column: x => x.LoadTeacherId,
                        principalTable: "LoadTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoadTeacherPeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoursFirstWeek = table.Column<int>(type: "int", nullable: false),
                    HoursSecondWeek = table.Column<int>(type: "int", nullable: false),
                    LoadTeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadTeacherPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadTeacherPeriods_LoadTeachers_LoadTeacherId",
                        column: x => x.LoadTeacherId,
                        principalTable: "LoadTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadTeacherPeriods_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_LoadTeacherId",
                table: "Schedules",
                column: "LoadTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadTeacherAuditoriums_AuditoriumId",
                table: "LoadTeacherAuditoriums",
                column: "AuditoriumId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadTeacherAuditoriums_LoadTeacherId",
                table: "LoadTeacherAuditoriums",
                column: "LoadTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadTeacherPeriods_LoadTeacherId",
                table: "LoadTeacherPeriods",
                column: "LoadTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadTeacherPeriods_PeriodId",
                table: "LoadTeacherPeriods",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadTeachers_DisciplineId",
                table: "LoadTeachers",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadTeachers_FlowId",
                table: "LoadTeachers",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadTeachers_TeacherId",
                table: "LoadTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadTeachers_TypeOfClassId",
                table: "LoadTeachers",
                column: "TypeOfClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_LoadTeachers_LoadTeacherId",
                table: "Schedules",
                column: "LoadTeacherId",
                principalTable: "LoadTeachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
