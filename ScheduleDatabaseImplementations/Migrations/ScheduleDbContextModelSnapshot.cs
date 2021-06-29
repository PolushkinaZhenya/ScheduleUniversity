﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScheduleImplementations;

namespace ScheduleDatabaseImplementations.Migrations
{
    [DbContext(typeof(ScheduleDbContext))]
    partial class ScheduleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScheduleModel.AcademicYear", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AcademicYears");
                });

            modelBuilder.Entity("ScheduleModel.Auditorium", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EducationalBuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeOfAudienceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EducationalBuildingId");

                    b.HasIndex("TypeOfAudienceId");

                    b.ToTable("Auditoriums");
                });

            modelBuilder.Entity("ScheduleModel.ClassTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("ClassTimes");
                });

            modelBuilder.Entity("ScheduleModel.Curriculum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumderOfHours")
                        .HasColumnType("int");

                    b.Property<Guid>("SemesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudyGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeOfClassId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("SemesterId");

                    b.HasIndex("StudyGroupId");

                    b.HasIndex("TypeOfClassId");

                    b.ToTable("Curriculums");
                });

            modelBuilder.Entity("ScheduleModel.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeOfDepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TypeOfDepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ScheduleModel.Discipline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AbbreviatedTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("ScheduleModel.EducationalBuilding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EducationalBuildings");
                });

            modelBuilder.Entity("ScheduleModel.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("ScheduleModel.Flow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("FlowAutoCreation")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flows");
                });

            modelBuilder.Entity("ScheduleModel.FlowStudyGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FlowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudyGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Subgroup")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlowId");

                    b.HasIndex("StudyGroupId");

                    b.ToTable("FlowStudyGroups");
                });

            modelBuilder.Entity("ScheduleModel.LoadTeacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FlowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("NumberOfSubgroups")
                        .HasColumnType("int");

                    b.Property<string>("Reporting")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeOfClassId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("FlowId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TypeOfClassId");

                    b.ToTable("LoadTeachers");
                });

            modelBuilder.Entity("ScheduleModel.LoadTeacherAuditorium", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuditoriumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LoadTeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuditoriumId");

                    b.HasIndex("LoadTeacherId");

                    b.ToTable("LoadTeacherAuditoriums");
                });

            modelBuilder.Entity("ScheduleModel.LoadTeacherPeriod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HoursFirstWeek")
                        .HasColumnType("int");

                    b.Property<int>("HoursSecondWeek")
                        .HasColumnType("int");

                    b.Property<Guid>("LoadTeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoadTeacherId");

                    b.HasIndex("PeriodId");

                    b.ToTable("LoadTeacherPeriods");
                });

            modelBuilder.Entity("ScheduleModel.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SemesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("ScheduleModel.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuditoriumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassTimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("DayOfTheWeek")
                        .HasColumnType("int");

                    b.Property<Guid?>("LoadTeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberWeeks")
                        .HasColumnType("int");

                    b.Property<Guid>("PeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StudyGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Subgroups")
                        .HasColumnType("int");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuditoriumId");

                    b.HasIndex("ClassTimeId");

                    b.HasIndex("LoadTeacherId");

                    b.HasIndex("PeriodId");

                    b.HasIndex("StudyGroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ScheduleModel.Semester", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AcademicYearId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AcademicYearId");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("ScheduleModel.Specialty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AbbreviatedTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("ScheduleModel.StudyGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Course")
                        .HasColumnType("int");

                    b.Property<int>("FormEducation")
                        .HasColumnType("int");

                    b.Property<int>("NumderStudents")
                        .HasColumnType("int");

                    b.Property<int>("NumderSubgroups")
                        .HasColumnType("int");

                    b.Property<Guid>("SpecialtyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeEducation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("StudyGroups");
                });

            modelBuilder.Entity("ScheduleModel.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ScheduleModel.TeacherDepartment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherDepartments");
                });

            modelBuilder.Entity("ScheduleModel.TransitionTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EducationalBuildingIdFrom")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EducationalBuildingIdTo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("EducationalBuildingIdFrom");

                    b.HasIndex("EducationalBuildingIdTo");

                    b.ToTable("TransitionTimes");
                });

            modelBuilder.Entity("ScheduleModel.TypeOfAudience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfAudiences");
                });

            modelBuilder.Entity("ScheduleModel.TypeOfClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AbbreviatedTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfClasses");
                });

            modelBuilder.Entity("ScheduleModel.TypeOfDepartment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfDepartments");
                });

            modelBuilder.Entity("ScheduleModel.Auditorium", b =>
                {
                    b.HasOne("ScheduleModel.Department", "Department")
                        .WithMany("Auditoriums")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.EducationalBuilding", "EducationalBuilding")
                        .WithMany("Auditoriums")
                        .HasForeignKey("EducationalBuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.TypeOfAudience", "TypeOfAudience")
                        .WithMany("Auditoriums")
                        .HasForeignKey("TypeOfAudienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("EducationalBuilding");

                    b.Navigation("TypeOfAudience");
                });

            modelBuilder.Entity("ScheduleModel.Curriculum", b =>
                {
                    b.HasOne("ScheduleModel.Discipline", "Discipline")
                        .WithMany("Curriculums")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.Semester", "Semester")
                        .WithMany("Curriculums")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.StudyGroup", "StudyGroup")
                        .WithMany("Curriculums")
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.TypeOfClass", "TypeOfClass")
                        .WithMany("Curriculums")
                        .HasForeignKey("TypeOfClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Semester");

                    b.Navigation("StudyGroup");

                    b.Navigation("TypeOfClass");
                });

            modelBuilder.Entity("ScheduleModel.Department", b =>
                {
                    b.HasOne("ScheduleModel.TypeOfDepartment", "TypeOfDepartment")
                        .WithMany("Departments")
                        .HasForeignKey("TypeOfDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfDepartment");
                });

            modelBuilder.Entity("ScheduleModel.FlowStudyGroup", b =>
                {
                    b.HasOne("ScheduleModel.Flow", "Flow")
                        .WithMany("FlowStudyGroups")
                        .HasForeignKey("FlowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.StudyGroup", "StudyGroup")
                        .WithMany("FlowStudyGroups")
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flow");

                    b.Navigation("StudyGroup");
                });

            modelBuilder.Entity("ScheduleModel.LoadTeacher", b =>
                {
                    b.HasOne("ScheduleModel.Discipline", "Discipline")
                        .WithMany("LoadTeachers")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.Flow", "Flow")
                        .WithMany("LoadTeachers")
                        .HasForeignKey("FlowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.Teacher", "Teacher")
                        .WithMany("LoadTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.TypeOfClass", "TypeOfClass")
                        .WithMany("LoadTeachers")
                        .HasForeignKey("TypeOfClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Flow");

                    b.Navigation("Teacher");

                    b.Navigation("TypeOfClass");
                });

            modelBuilder.Entity("ScheduleModel.LoadTeacherAuditorium", b =>
                {
                    b.HasOne("ScheduleModel.Auditorium", "Auditorium")
                        .WithMany("LoadTeacherAuditoriums")
                        .HasForeignKey("AuditoriumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.LoadTeacher", "LoadTeacher")
                        .WithMany("LoadTeacherAuditoriums")
                        .HasForeignKey("LoadTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditorium");

                    b.Navigation("LoadTeacher");
                });

            modelBuilder.Entity("ScheduleModel.LoadTeacherPeriod", b =>
                {
                    b.HasOne("ScheduleModel.LoadTeacher", "LoadTeacher")
                        .WithMany("LoadTeacherPeriods")
                        .HasForeignKey("LoadTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.Period", "Period")
                        .WithMany("LoadTeacherPeriods")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoadTeacher");

                    b.Navigation("Period");
                });

            modelBuilder.Entity("ScheduleModel.Period", b =>
                {
                    b.HasOne("ScheduleModel.Semester", "Semester")
                        .WithMany("Periods")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("ScheduleModel.Schedule", b =>
                {
                    b.HasOne("ScheduleModel.Auditorium", "Auditorium")
                        .WithMany("Schedules")
                        .HasForeignKey("AuditoriumId");

                    b.HasOne("ScheduleModel.ClassTime", "ClassTime")
                        .WithMany("Schedules")
                        .HasForeignKey("ClassTimeId");

                    b.HasOne("ScheduleModel.LoadTeacher", "LoadTeacher")
                        .WithMany("Schedules")
                        .HasForeignKey("LoadTeacherId");

                    b.HasOne("ScheduleModel.Period", "Period")
                        .WithMany("Schedules")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.StudyGroup", "StudyGroup")
                        .WithMany("Schedules")
                        .HasForeignKey("StudyGroupId");

                    b.HasOne("ScheduleModel.Teacher", "Teacher")
                        .WithMany("Schedules")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Auditorium");

                    b.Navigation("ClassTime");

                    b.Navigation("LoadTeacher");

                    b.Navigation("Period");

                    b.Navigation("StudyGroup");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ScheduleModel.Semester", b =>
                {
                    b.HasOne("ScheduleModel.AcademicYear", "AcademicYear")
                        .WithMany("Semesters")
                        .HasForeignKey("AcademicYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicYear");
                });

            modelBuilder.Entity("ScheduleModel.Specialty", b =>
                {
                    b.HasOne("ScheduleModel.Faculty", "Faculty")
                        .WithMany("Specialties")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("ScheduleModel.StudyGroup", b =>
                {
                    b.HasOne("ScheduleModel.Specialty", "Specialty")
                        .WithMany("StudyGroups")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("ScheduleModel.TeacherDepartment", b =>
                {
                    b.HasOne("ScheduleModel.Department", "Department")
                        .WithMany("TeacherDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.Teacher", "Teacher")
                        .WithMany("TeacherDepartments")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ScheduleModel.TransitionTime", b =>
                {
                    b.HasOne("ScheduleModel.EducationalBuilding", "EducationalBuildingFrom")
                        .WithMany("TransitionTimesFrom")
                        .HasForeignKey("EducationalBuildingIdFrom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModel.EducationalBuilding", "EducationalBuildingTo")
                        .WithMany("TransitionTimesTo")
                        .HasForeignKey("EducationalBuildingIdTo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EducationalBuildingFrom");

                    b.Navigation("EducationalBuildingTo");
                });

            modelBuilder.Entity("ScheduleModel.AcademicYear", b =>
                {
                    b.Navigation("Semesters");
                });

            modelBuilder.Entity("ScheduleModel.Auditorium", b =>
                {
                    b.Navigation("LoadTeacherAuditoriums");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModel.ClassTime", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModel.Department", b =>
                {
                    b.Navigation("Auditoriums");

                    b.Navigation("TeacherDepartments");
                });

            modelBuilder.Entity("ScheduleModel.Discipline", b =>
                {
                    b.Navigation("Curriculums");

                    b.Navigation("LoadTeachers");
                });

            modelBuilder.Entity("ScheduleModel.EducationalBuilding", b =>
                {
                    b.Navigation("Auditoriums");

                    b.Navigation("TransitionTimesFrom");

                    b.Navigation("TransitionTimesTo");
                });

            modelBuilder.Entity("ScheduleModel.Faculty", b =>
                {
                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("ScheduleModel.Flow", b =>
                {
                    b.Navigation("FlowStudyGroups");

                    b.Navigation("LoadTeachers");
                });

            modelBuilder.Entity("ScheduleModel.LoadTeacher", b =>
                {
                    b.Navigation("LoadTeacherAuditoriums");

                    b.Navigation("LoadTeacherPeriods");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModel.Period", b =>
                {
                    b.Navigation("LoadTeacherPeriods");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModel.Semester", b =>
                {
                    b.Navigation("Curriculums");

                    b.Navigation("Periods");
                });

            modelBuilder.Entity("ScheduleModel.Specialty", b =>
                {
                    b.Navigation("StudyGroups");
                });

            modelBuilder.Entity("ScheduleModel.StudyGroup", b =>
                {
                    b.Navigation("Curriculums");

                    b.Navigation("FlowStudyGroups");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModel.Teacher", b =>
                {
                    b.Navigation("LoadTeachers");

                    b.Navigation("Schedules");

                    b.Navigation("TeacherDepartments");
                });

            modelBuilder.Entity("ScheduleModel.TypeOfAudience", b =>
                {
                    b.Navigation("Auditoriums");
                });

            modelBuilder.Entity("ScheduleModel.TypeOfClass", b =>
                {
                    b.Navigation("Curriculums");

                    b.Navigation("LoadTeachers");
                });

            modelBuilder.Entity("ScheduleModel.TypeOfDepartment", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
