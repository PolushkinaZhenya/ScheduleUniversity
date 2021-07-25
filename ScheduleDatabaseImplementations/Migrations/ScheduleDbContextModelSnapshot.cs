﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScheduleDatabaseImplementations;

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

            modelBuilder.Entity("ScheduleModels.AcademicYear", b =>
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

            modelBuilder.Entity("ScheduleModels.Auditorium", b =>
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

            modelBuilder.Entity("ScheduleModels.ClassTime", b =>
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

            modelBuilder.Entity("ScheduleModels.Curriculum", b =>
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

            modelBuilder.Entity("ScheduleModels.Department", b =>
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

            modelBuilder.Entity("ScheduleModels.Discipline", b =>
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

            modelBuilder.Entity("ScheduleModels.EducationalBuilding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EducationalBuildings");
                });

            modelBuilder.Entity("ScheduleModels.Faculty", b =>
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

            modelBuilder.Entity("ScheduleModels.Flow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flows");
                });

            modelBuilder.Entity("ScheduleModels.FlowStudyGroup", b =>
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

            modelBuilder.Entity("ScheduleModels.HourOfSemester", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reporting")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SemesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudyGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Wishes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("SemesterId");

                    b.HasIndex("StudyGroupId");

                    b.ToTable("HourOfSemesters");
                });

            modelBuilder.Entity("ScheduleModels.HourOfSemesterAuditorium", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuditoriumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HourOfSemesterRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuditoriumId");

                    b.HasIndex("HourOfSemesterRecordId");

                    b.ToTable("HourOfSemesterAuditoriums");
                });

            modelBuilder.Entity("ScheduleModels.HourOfSemesterPeriod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HourOfSemesterRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HoursFirstWeek")
                        .HasColumnType("int");

                    b.Property<int>("HoursSecondWeek")
                        .HasColumnType("int");

                    b.Property<Guid>("PeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HourOfSemesterRecordId");

                    b.HasIndex("PeriodId");

                    b.ToTable("HourOfSemesterPeriods");
                });

            modelBuilder.Entity("ScheduleModels.HourOfSemesterRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HourOfSemesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SubgroupNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.Property<Guid>("TypeOfClassId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FlowId");

                    b.HasIndex("HourOfSemesterId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TypeOfClassId");

                    b.ToTable("HourOfSemesterRecords");
                });

            modelBuilder.Entity("ScheduleModels.Period", b =>
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

            modelBuilder.Entity("ScheduleModels.Schedule", b =>
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

                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HourOfSemesterPeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberWeeks")
                        .HasColumnType("int");

                    b.Property<Guid>("StudyGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SubgroupNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeOfClassId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuditoriumId");

                    b.HasIndex("ClassTimeId");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("FlowId");

                    b.HasIndex("HourOfSemesterPeriodId");

                    b.HasIndex("StudyGroupId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TypeOfClassId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ScheduleModels.Semester", b =>
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

            modelBuilder.Entity("ScheduleModels.Specialty", b =>
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

            modelBuilder.Entity("ScheduleModels.StudyGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Course")
                        .HasColumnType("int");

                    b.Property<int>("FormEducation")
                        .HasColumnType("int");

                    b.Property<int>("GroupNumber")
                        .HasColumnType("int");

                    b.Property<int>("NumderStudents")
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

            modelBuilder.Entity("ScheduleModels.Teacher", b =>
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

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ScheduleModels.TeacherDepartment", b =>
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

            modelBuilder.Entity("ScheduleModels.TransitionTime", b =>
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

            modelBuilder.Entity("ScheduleModels.TypeOfAudience", b =>
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

            modelBuilder.Entity("ScheduleModels.TypeOfClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AbbreviatedTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfClasses");
                });

            modelBuilder.Entity("ScheduleModels.TypeOfDepartment", b =>
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

            modelBuilder.Entity("ScheduleModels.Auditorium", b =>
                {
                    b.HasOne("ScheduleModels.Department", "Department")
                        .WithMany("Auditoriums")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.EducationalBuilding", "EducationalBuilding")
                        .WithMany("Auditoriums")
                        .HasForeignKey("EducationalBuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.TypeOfAudience", "TypeOfAudience")
                        .WithMany("Auditoriums")
                        .HasForeignKey("TypeOfAudienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("EducationalBuilding");

                    b.Navigation("TypeOfAudience");
                });

            modelBuilder.Entity("ScheduleModels.Curriculum", b =>
                {
                    b.HasOne("ScheduleModels.Discipline", "Discipline")
                        .WithMany("Curriculums")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.Semester", "Semester")
                        .WithMany("Curriculums")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.StudyGroup", "StudyGroup")
                        .WithMany("Curriculums")
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.TypeOfClass", "TypeOfClass")
                        .WithMany("Curriculums")
                        .HasForeignKey("TypeOfClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Semester");

                    b.Navigation("StudyGroup");

                    b.Navigation("TypeOfClass");
                });

            modelBuilder.Entity("ScheduleModels.Department", b =>
                {
                    b.HasOne("ScheduleModels.TypeOfDepartment", "TypeOfDepartment")
                        .WithMany("Departments")
                        .HasForeignKey("TypeOfDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfDepartment");
                });

            modelBuilder.Entity("ScheduleModels.FlowStudyGroup", b =>
                {
                    b.HasOne("ScheduleModels.Flow", "Flow")
                        .WithMany("FlowStudyGroups")
                        .HasForeignKey("FlowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.StudyGroup", "StudyGroup")
                        .WithMany("FlowStudyGroups")
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flow");

                    b.Navigation("StudyGroup");
                });

            modelBuilder.Entity("ScheduleModels.HourOfSemester", b =>
                {
                    b.HasOne("ScheduleModels.Discipline", "Discipline")
                        .WithMany("LoadTeachers")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.Semester", "Semester")
                        .WithMany("HourOfSemesters")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.StudyGroup", "StudyGroup")
                        .WithMany("HourOfSemesters")
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Semester");

                    b.Navigation("StudyGroup");
                });

            modelBuilder.Entity("ScheduleModels.HourOfSemesterAuditorium", b =>
                {
                    b.HasOne("ScheduleModels.Auditorium", "Auditorium")
                        .WithMany("LoadTeacherAuditoriums")
                        .HasForeignKey("AuditoriumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.HourOfSemesterRecord", "HourOfSemesterRecord")
                        .WithMany("HourOfSemesterAuditoriums")
                        .HasForeignKey("HourOfSemesterRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditorium");

                    b.Navigation("HourOfSemesterRecord");
                });

            modelBuilder.Entity("ScheduleModels.HourOfSemesterPeriod", b =>
                {
                    b.HasOne("ScheduleModels.HourOfSemesterRecord", "HourOfSemesterRecord")
                        .WithMany("HourOfSemesterPeriods")
                        .HasForeignKey("HourOfSemesterRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.Period", "Period")
                        .WithMany("HourOfSemesterPeriods")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("HourOfSemesterRecord");

                    b.Navigation("Period");
                });

            modelBuilder.Entity("ScheduleModels.HourOfSemesterRecord", b =>
                {
                    b.HasOne("ScheduleModels.Flow", "Flow")
                        .WithMany("HourOfSemesterRecords")
                        .HasForeignKey("FlowId");

                    b.HasOne("ScheduleModels.HourOfSemester", "HourOfSemester")
                        .WithMany("HourOfSemesterRecords")
                        .HasForeignKey("HourOfSemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.Teacher", "Teacher")
                        .WithMany("HourOfSemesterRecords")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.TypeOfClass", "TypeOfClass")
                        .WithMany("HourOfSemesterRecords")
                        .HasForeignKey("TypeOfClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flow");

                    b.Navigation("HourOfSemester");

                    b.Navigation("Teacher");

                    b.Navigation("TypeOfClass");
                });

            modelBuilder.Entity("ScheduleModels.Period", b =>
                {
                    b.HasOne("ScheduleModels.Semester", "Semester")
                        .WithMany("Periods")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("ScheduleModels.Schedule", b =>
                {
                    b.HasOne("ScheduleModels.Auditorium", "Auditorium")
                        .WithMany("Schedules")
                        .HasForeignKey("AuditoriumId");

                    b.HasOne("ScheduleModels.ClassTime", "ClassTime")
                        .WithMany("Schedules")
                        .HasForeignKey("ClassTimeId");

                    b.HasOne("ScheduleModels.Discipline", "Discipline")
                        .WithMany("Schedules")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ScheduleModels.Flow", "Flow")
                        .WithMany("Schedules")
                        .HasForeignKey("FlowId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ScheduleModels.HourOfSemesterPeriod", "HourOfSemesterPeriod")
                        .WithMany("Schedules")
                        .HasForeignKey("HourOfSemesterPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.StudyGroup", "StudyGroup")
                        .WithMany("Schedules")
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ScheduleModels.Teacher", "Teacher")
                        .WithMany("Schedules")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ScheduleModels.TypeOfClass", "TypeOfClass")
                        .WithMany("Schedules")
                        .HasForeignKey("TypeOfClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Auditorium");

                    b.Navigation("ClassTime");

                    b.Navigation("Discipline");

                    b.Navigation("Flow");

                    b.Navigation("HourOfSemesterPeriod");

                    b.Navigation("StudyGroup");

                    b.Navigation("Teacher");

                    b.Navigation("TypeOfClass");
                });

            modelBuilder.Entity("ScheduleModels.Semester", b =>
                {
                    b.HasOne("ScheduleModels.AcademicYear", "AcademicYear")
                        .WithMany("Semesters")
                        .HasForeignKey("AcademicYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicYear");
                });

            modelBuilder.Entity("ScheduleModels.Specialty", b =>
                {
                    b.HasOne("ScheduleModels.Faculty", "Faculty")
                        .WithMany("Specialties")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("ScheduleModels.StudyGroup", b =>
                {
                    b.HasOne("ScheduleModels.Specialty", "Specialty")
                        .WithMany("StudyGroups")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("ScheduleModels.TeacherDepartment", b =>
                {
                    b.HasOne("ScheduleModels.Department", "Department")
                        .WithMany("TeacherDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.Teacher", "Teacher")
                        .WithMany("TeacherDepartments")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ScheduleModels.TransitionTime", b =>
                {
                    b.HasOne("ScheduleModels.EducationalBuilding", "EducationalBuildingFrom")
                        .WithMany("TransitionTimesFrom")
                        .HasForeignKey("EducationalBuildingIdFrom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleModels.EducationalBuilding", "EducationalBuildingTo")
                        .WithMany("TransitionTimesTo")
                        .HasForeignKey("EducationalBuildingIdTo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EducationalBuildingFrom");

                    b.Navigation("EducationalBuildingTo");
                });

            modelBuilder.Entity("ScheduleModels.AcademicYear", b =>
                {
                    b.Navigation("Semesters");
                });

            modelBuilder.Entity("ScheduleModels.Auditorium", b =>
                {
                    b.Navigation("LoadTeacherAuditoriums");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModels.ClassTime", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModels.Department", b =>
                {
                    b.Navigation("Auditoriums");

                    b.Navigation("TeacherDepartments");
                });

            modelBuilder.Entity("ScheduleModels.Discipline", b =>
                {
                    b.Navigation("Curriculums");

                    b.Navigation("LoadTeachers");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModels.EducationalBuilding", b =>
                {
                    b.Navigation("Auditoriums");

                    b.Navigation("TransitionTimesFrom");

                    b.Navigation("TransitionTimesTo");
                });

            modelBuilder.Entity("ScheduleModels.Faculty", b =>
                {
                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("ScheduleModels.Flow", b =>
                {
                    b.Navigation("FlowStudyGroups");

                    b.Navigation("HourOfSemesterRecords");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModels.HourOfSemester", b =>
                {
                    b.Navigation("HourOfSemesterRecords");
                });

            modelBuilder.Entity("ScheduleModels.HourOfSemesterPeriod", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModels.HourOfSemesterRecord", b =>
                {
                    b.Navigation("HourOfSemesterAuditoriums");

                    b.Navigation("HourOfSemesterPeriods");
                });

            modelBuilder.Entity("ScheduleModels.Period", b =>
                {
                    b.Navigation("HourOfSemesterPeriods");
                });

            modelBuilder.Entity("ScheduleModels.Semester", b =>
                {
                    b.Navigation("Curriculums");

                    b.Navigation("HourOfSemesters");

                    b.Navigation("Periods");
                });

            modelBuilder.Entity("ScheduleModels.Specialty", b =>
                {
                    b.Navigation("StudyGroups");
                });

            modelBuilder.Entity("ScheduleModels.StudyGroup", b =>
                {
                    b.Navigation("Curriculums");

                    b.Navigation("FlowStudyGroups");

                    b.Navigation("HourOfSemesters");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModels.Teacher", b =>
                {
                    b.Navigation("HourOfSemesterRecords");

                    b.Navigation("Schedules");

                    b.Navigation("TeacherDepartments");
                });

            modelBuilder.Entity("ScheduleModels.TypeOfAudience", b =>
                {
                    b.Navigation("Auditoriums");
                });

            modelBuilder.Entity("ScheduleModels.TypeOfClass", b =>
                {
                    b.Navigation("Curriculums");

                    b.Navigation("HourOfSemesterRecords");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ScheduleModels.TypeOfDepartment", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
