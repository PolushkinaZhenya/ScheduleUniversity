namespace ScheduleImplementations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auditoriums",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        EducationalBuildingId = c.Guid(nullable: false),
                        TypeOfAudienceId = c.Guid(nullable: false),
                        DepartmentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.EducationalBuildings", t => t.EducationalBuildingId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfAudiences", t => t.TypeOfAudienceId, cascadeDelete: true)
                .Index(t => t.EducationalBuildingId)
                .Index(t => t.TypeOfAudienceId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        TypeOfDepartmentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeOfDepartments", t => t.TypeOfDepartmentId, cascadeDelete: true)
                .Index(t => t.TypeOfDepartmentId);
            
            CreateTable(
                "dbo.TeacherDepartments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TeacherId = c.Guid(nullable: false),
                        DepartmentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Surname = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Patronymic = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DayOfWeek = c.Int(nullable: false),
                        Subgroups = c.Int(nullable: false),
                        NumberWeeks = c.Int(nullable: false),
                        AuditoriumId = c.Guid(nullable: false),
                        ClassTimeId = c.Guid(nullable: false),
                        TeacherId = c.Guid(nullable: false),
                        TypeOfClassId = c.Guid(nullable: false),
                        DisciplineId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auditoriums", t => t.AuditoriumId, cascadeDelete: true)
                .ForeignKey("dbo.ClassTimes", t => t.ClassTimeId, cascadeDelete: true)
                .ForeignKey("dbo.Disciplines", t => t.DisciplineId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfClasses", t => t.TypeOfClassId, cascadeDelete: true)
                .Index(t => t.AuditoriumId)
                .Index(t => t.ClassTimeId)
                .Index(t => t.TeacherId)
                .Index(t => t.TypeOfClassId)
                .Index(t => t.DisciplineId);
            
            CreateTable(
                "dbo.ClassTimes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        AbbreviatedTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfClasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        AbbreviatedTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfDepartments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EducationalBuildings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransitionTimes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        EducationalBuildingId_1 = c.Guid(nullable: false),
                        EducationalBuildingId_2 = c.Guid(nullable: false),
                        EducationalBuilding_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EducationalBuildings", t => t.EducationalBuilding_Id)
                .ForeignKey("dbo.EducationalBuildings", t => t.EducationalBuildingId_1, cascadeDelete: true)
                .ForeignKey("dbo.EducationalBuildings", t => t.EducationalBuildingId_2, cascadeDelete: false)
                .Index(t => t.EducationalBuildingId_1)
                .Index(t => t.EducationalBuildingId_2)
                .Index(t => t.EducationalBuilding_Id);
            
            CreateTable(
                "dbo.TypeOfAudiences",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        AbbreviatedTitle = c.String(nullable: false),
                        FacultyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specialties", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Auditoriums", "TypeOfAudienceId", "dbo.TypeOfAudiences");
            DropForeignKey("dbo.TransitionTimes", "EducationalBuildingId_2", "dbo.EducationalBuildings");
            DropForeignKey("dbo.TransitionTimes", "EducationalBuildingId_1", "dbo.EducationalBuildings");
            DropForeignKey("dbo.TransitionTimes", "EducationalBuilding_Id", "dbo.EducationalBuildings");
            DropForeignKey("dbo.Auditoriums", "EducationalBuildingId", "dbo.EducationalBuildings");
            DropForeignKey("dbo.Departments", "TypeOfDepartmentId", "dbo.TypeOfDepartments");
            DropForeignKey("dbo.TeacherDepartments", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Schedules", "TypeOfClassId", "dbo.TypeOfClasses");
            DropForeignKey("dbo.Schedules", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Schedules", "DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.Schedules", "ClassTimeId", "dbo.ClassTimes");
            DropForeignKey("dbo.Schedules", "AuditoriumId", "dbo.Auditoriums");
            DropForeignKey("dbo.TeacherDepartments", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Auditoriums", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Specialties", new[] { "FacultyId" });
            DropIndex("dbo.TransitionTimes", new[] { "EducationalBuilding_Id" });
            DropIndex("dbo.TransitionTimes", new[] { "EducationalBuildingId_2" });
            DropIndex("dbo.TransitionTimes", new[] { "EducationalBuildingId_1" });
            DropIndex("dbo.Schedules", new[] { "DisciplineId" });
            DropIndex("dbo.Schedules", new[] { "TypeOfClassId" });
            DropIndex("dbo.Schedules", new[] { "TeacherId" });
            DropIndex("dbo.Schedules", new[] { "ClassTimeId" });
            DropIndex("dbo.Schedules", new[] { "AuditoriumId" });
            DropIndex("dbo.TeacherDepartments", new[] { "DepartmentId" });
            DropIndex("dbo.TeacherDepartments", new[] { "TeacherId" });
            DropIndex("dbo.Departments", new[] { "TypeOfDepartmentId" });
            DropIndex("dbo.Auditoriums", new[] { "DepartmentId" });
            DropIndex("dbo.Auditoriums", new[] { "TypeOfAudienceId" });
            DropIndex("dbo.Auditoriums", new[] { "EducationalBuildingId" });
            DropTable("dbo.Specialties");
            DropTable("dbo.Faculties");
            DropTable("dbo.TypeOfAudiences");
            DropTable("dbo.TransitionTimes");
            DropTable("dbo.EducationalBuildings");
            DropTable("dbo.TypeOfDepartments");
            DropTable("dbo.TypeOfClasses");
            DropTable("dbo.Disciplines");
            DropTable("dbo.ClassTimes");
            DropTable("dbo.Schedules");
            DropTable("dbo.Teachers");
            DropTable("dbo.TeacherDepartments");
            DropTable("dbo.Departments");
            DropTable("dbo.Auditoriums");
        }
    }
}
