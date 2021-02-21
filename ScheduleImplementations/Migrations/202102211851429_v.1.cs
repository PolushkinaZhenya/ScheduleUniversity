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
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        EducationalBuildingId = c.Int(nullable: false),
                        TypeOfAudienceId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
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
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherDepartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
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
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Patronymic = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EducationalBuildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransitionTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.Time(nullable: false, precision: 7),
                        EducationalBuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EducationalBuildings", t => t.EducationalBuildingId, cascadeDelete: true)
                .Index(t => t.EducationalBuildingId);
            
            CreateTable(
                "dbo.TypeOfAudiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auditoriums", "TypeOfAudienceId", "dbo.TypeOfAudiences");
            DropForeignKey("dbo.TransitionTimes", "EducationalBuildingId", "dbo.EducationalBuildings");
            DropForeignKey("dbo.Auditoriums", "EducationalBuildingId", "dbo.EducationalBuildings");
            DropForeignKey("dbo.TeacherDepartments", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherDepartments", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Auditoriums", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.TransitionTimes", new[] { "EducationalBuildingId" });
            DropIndex("dbo.TeacherDepartments", new[] { "DepartmentId" });
            DropIndex("dbo.TeacherDepartments", new[] { "TeacherId" });
            DropIndex("dbo.Auditoriums", new[] { "DepartmentId" });
            DropIndex("dbo.Auditoriums", new[] { "TypeOfAudienceId" });
            DropIndex("dbo.Auditoriums", new[] { "EducationalBuildingId" });
            DropTable("dbo.ClassTimes");
            DropTable("dbo.TypeOfAudiences");
            DropTable("dbo.TransitionTimes");
            DropTable("dbo.EducationalBuildings");
            DropTable("dbo.Teachers");
            DropTable("dbo.TeacherDepartments");
            DropTable("dbo.Departments");
            DropTable("dbo.Auditoriums");
        }
    }
}
