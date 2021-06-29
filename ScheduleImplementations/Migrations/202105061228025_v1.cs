namespace ScheduleDatabaseImplementations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicYears",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        AcademicYearId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearId, cascadeDelete: true)
                .Index(t => t.AcademicYearId);
            
            CreateTable(
                "dbo.Curricula",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DisciplineId = c.Guid(nullable: false),
                        StudyGroupId = c.Guid(nullable: false),
                        TypeOfClassId = c.Guid(nullable: false),
                        SemesterId = c.Guid(nullable: false),
                        NumderOfHours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.DisciplineId, cascadeDelete: true)
                .ForeignKey("dbo.StudyGroups", t => t.StudyGroupId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfClasses", t => t.TypeOfClassId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.DisciplineId)
                .Index(t => t.StudyGroupId)
                .Index(t => t.TypeOfClassId)
                .Index(t => t.SemesterId);
            
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
                "dbo.LoadTeachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DisciplineId = c.Guid(nullable: false),
                        TypeOfClassId = c.Guid(nullable: false),
                        TeacherId = c.Guid(nullable: false),
                        FlowId = c.Guid(nullable: false),
                        Reporting = c.String(),
                        NumberOfSubgroups = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.DisciplineId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Flows", t => t.FlowId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfClasses", t => t.TypeOfClassId, cascadeDelete: true)
                .Index(t => t.DisciplineId)
                .Index(t => t.TypeOfClassId)
                .Index(t => t.TeacherId)
                .Index(t => t.FlowId);
            
            CreateTable(
                "dbo.Flows",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        FlowAutoCreation = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlowStudyGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FlowId = c.Guid(nullable: false),
                        StudyGroupId = c.Guid(nullable: false),
                        Subgroup = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flows", t => t.FlowId, cascadeDelete: true)
                .ForeignKey("dbo.StudyGroups", t => t.StudyGroupId, cascadeDelete: true)
                .Index(t => t.FlowId)
                .Index(t => t.StudyGroupId);
            
            CreateTable(
                "dbo.StudyGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Course = c.Int(nullable: false),
                        NumderStudents = c.Int(nullable: false),
                        NumderSubgroups = c.Int(nullable: false),
                        SpecialtyId = c.Guid(nullable: false),
                        TypeEducation = c.Int(nullable: false),
                        FormEducation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyId, cascadeDelete: true)
                .Index(t => t.SpecialtyId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PeriodId = c.Guid(nullable: false),
                        DayOfTheWeek = c.Int(),
                        NumberWeeks = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        AuditoriumId = c.Guid(),
                        ClassTimeId = c.Guid(),
                        StudyGroupId = c.Guid(),
                        Subgroups = c.Int(),
                        LoadTeacherId = c.Guid(),
                        TeacherId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Auditoriums", t => t.AuditoriumId)
                .ForeignKey("dbo.ClassTimes", t => t.ClassTimeId)
                .ForeignKey("dbo.LoadTeachers", t => t.LoadTeacherId)
                .ForeignKey("dbo.Periods", t => t.PeriodId, cascadeDelete: true)
                .ForeignKey("dbo.StudyGroups", t => t.StudyGroupId)
                .Index(t => t.PeriodId)
                .Index(t => t.AuditoriumId)
                .Index(t => t.ClassTimeId)
                .Index(t => t.StudyGroupId)
                .Index(t => t.LoadTeacherId)
                .Index(t => t.TeacherId);
            
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
                "dbo.LoadTeacherAuditoriums",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoadTeacherId = c.Guid(nullable: false),
                        AuditoriumId = c.Guid(nullable: false),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auditoriums", t => t.AuditoriumId, cascadeDelete: true)
                .ForeignKey("dbo.LoadTeachers", t => t.LoadTeacherId, cascadeDelete: true)
                .Index(t => t.LoadTeacherId)
                .Index(t => t.AuditoriumId);
            
            CreateTable(
                "dbo.TypeOfAudiences",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Periods",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        SemesterId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.LoadTeacherPeriods",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoadTeacherId = c.Guid(nullable: false),
                        PeriodId = c.Guid(nullable: false),
                        TotalHours = c.Int(nullable: false),
                        HoursFirstWeek = c.Int(nullable: false),
                        HoursSecondWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoadTeachers", t => t.LoadTeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Periods", t => t.PeriodId, cascadeDelete: true)
                .Index(t => t.LoadTeacherId)
                .Index(t => t.PeriodId);
            
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
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Curricula", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.LoadTeachers", "TypeOfClassId", "dbo.TypeOfClasses");
            DropForeignKey("dbo.Curricula", "TypeOfClassId", "dbo.TypeOfClasses");
            DropForeignKey("dbo.LoadTeachers", "FlowId", "dbo.Flows");
            DropForeignKey("dbo.StudyGroups", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Specialties", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Schedules", "StudyGroupId", "dbo.StudyGroups");
            DropForeignKey("dbo.Periods", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Schedules", "PeriodId", "dbo.Periods");
            DropForeignKey("dbo.LoadTeacherPeriods", "PeriodId", "dbo.Periods");
            DropForeignKey("dbo.LoadTeacherPeriods", "LoadTeacherId", "dbo.LoadTeachers");
            DropForeignKey("dbo.Schedules", "LoadTeacherId", "dbo.LoadTeachers");
            DropForeignKey("dbo.Schedules", "ClassTimeId", "dbo.ClassTimes");
            DropForeignKey("dbo.Auditoriums", "TypeOfAudienceId", "dbo.TypeOfAudiences");
            DropForeignKey("dbo.Schedules", "AuditoriumId", "dbo.Auditoriums");
            DropForeignKey("dbo.LoadTeacherAuditoriums", "LoadTeacherId", "dbo.LoadTeachers");
            DropForeignKey("dbo.LoadTeacherAuditoriums", "AuditoriumId", "dbo.Auditoriums");
            DropForeignKey("dbo.TransitionTimes", "EducationalBuildingId_2", "dbo.EducationalBuildings");
            DropForeignKey("dbo.TransitionTimes", "EducationalBuildingId_1", "dbo.EducationalBuildings");
            DropForeignKey("dbo.TransitionTimes", "EducationalBuilding_Id", "dbo.EducationalBuildings");
            DropForeignKey("dbo.Auditoriums", "EducationalBuildingId", "dbo.EducationalBuildings");
            DropForeignKey("dbo.Departments", "TypeOfDepartmentId", "dbo.TypeOfDepartments");
            DropForeignKey("dbo.TeacherDepartments", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Schedules", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.LoadTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherDepartments", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Auditoriums", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.FlowStudyGroups", "StudyGroupId", "dbo.StudyGroups");
            DropForeignKey("dbo.Curricula", "StudyGroupId", "dbo.StudyGroups");
            DropForeignKey("dbo.FlowStudyGroups", "FlowId", "dbo.Flows");
            DropForeignKey("dbo.LoadTeachers", "DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.Curricula", "DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.Semesters", "AcademicYearId", "dbo.AcademicYears");
            DropIndex("dbo.Specialties", new[] { "FacultyId" });
            DropIndex("dbo.LoadTeacherPeriods", new[] { "PeriodId" });
            DropIndex("dbo.LoadTeacherPeriods", new[] { "LoadTeacherId" });
            DropIndex("dbo.Periods", new[] { "SemesterId" });
            DropIndex("dbo.LoadTeacherAuditoriums", new[] { "AuditoriumId" });
            DropIndex("dbo.LoadTeacherAuditoriums", new[] { "LoadTeacherId" });
            DropIndex("dbo.TransitionTimes", new[] { "EducationalBuilding_Id" });
            DropIndex("dbo.TransitionTimes", new[] { "EducationalBuildingId_2" });
            DropIndex("dbo.TransitionTimes", new[] { "EducationalBuildingId_1" });
            DropIndex("dbo.TeacherDepartments", new[] { "DepartmentId" });
            DropIndex("dbo.TeacherDepartments", new[] { "TeacherId" });
            DropIndex("dbo.Departments", new[] { "TypeOfDepartmentId" });
            DropIndex("dbo.Auditoriums", new[] { "DepartmentId" });
            DropIndex("dbo.Auditoriums", new[] { "TypeOfAudienceId" });
            DropIndex("dbo.Auditoriums", new[] { "EducationalBuildingId" });
            DropIndex("dbo.Schedules", new[] { "TeacherId" });
            DropIndex("dbo.Schedules", new[] { "LoadTeacherId" });
            DropIndex("dbo.Schedules", new[] { "StudyGroupId" });
            DropIndex("dbo.Schedules", new[] { "ClassTimeId" });
            DropIndex("dbo.Schedules", new[] { "AuditoriumId" });
            DropIndex("dbo.Schedules", new[] { "PeriodId" });
            DropIndex("dbo.StudyGroups", new[] { "SpecialtyId" });
            DropIndex("dbo.FlowStudyGroups", new[] { "StudyGroupId" });
            DropIndex("dbo.FlowStudyGroups", new[] { "FlowId" });
            DropIndex("dbo.LoadTeachers", new[] { "FlowId" });
            DropIndex("dbo.LoadTeachers", new[] { "TeacherId" });
            DropIndex("dbo.LoadTeachers", new[] { "TypeOfClassId" });
            DropIndex("dbo.LoadTeachers", new[] { "DisciplineId" });
            DropIndex("dbo.Curricula", new[] { "SemesterId" });
            DropIndex("dbo.Curricula", new[] { "TypeOfClassId" });
            DropIndex("dbo.Curricula", new[] { "StudyGroupId" });
            DropIndex("dbo.Curricula", new[] { "DisciplineId" });
            DropIndex("dbo.Semesters", new[] { "AcademicYearId" });
            DropTable("dbo.TypeOfClasses");
            DropTable("dbo.Faculties");
            DropTable("dbo.Specialties");
            DropTable("dbo.LoadTeacherPeriods");
            DropTable("dbo.Periods");
            DropTable("dbo.ClassTimes");
            DropTable("dbo.TypeOfAudiences");
            DropTable("dbo.LoadTeacherAuditoriums");
            DropTable("dbo.TransitionTimes");
            DropTable("dbo.EducationalBuildings");
            DropTable("dbo.TypeOfDepartments");
            DropTable("dbo.Teachers");
            DropTable("dbo.TeacherDepartments");
            DropTable("dbo.Departments");
            DropTable("dbo.Auditoriums");
            DropTable("dbo.Schedules");
            DropTable("dbo.StudyGroups");
            DropTable("dbo.FlowStudyGroups");
            DropTable("dbo.Flows");
            DropTable("dbo.LoadTeachers");
            DropTable("dbo.Disciplines");
            DropTable("dbo.Curricula");
            DropTable("dbo.Semesters");
            DropTable("dbo.AcademicYears");
        }
    }
}
