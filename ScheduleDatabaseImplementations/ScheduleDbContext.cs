using Microsoft.EntityFrameworkCore;
using ScheduleModels;

namespace ScheduleDatabaseImplementations
{
	public class ScheduleDbContext : DbContext
    {
		public ScheduleDbContext() : base()
		{
		}

		public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : base(options)
        {
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#if DEBUG
				optionsBuilder.UseSqlServer(@"Data Source=CHESHIR\SQLEXPRESS;Initial Catalog=ScheduleULSTU;persist security info=True;user id=admin;password=cheshirSA123;MultipleActiveResultSets=True;");
#endif
			}
			base.OnConfiguring(optionsBuilder);
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransitionTime>()
                .HasOne(x => x.EducationalBuildingFrom)
                .WithMany(p => p.TransitionTimesFrom)
                .HasForeignKey(pt => pt.EducationalBuildingIdFrom)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransitionTime>()
                .HasOne(x => x.EducationalBuildingTo)
                .WithMany(p => p.TransitionTimesTo)
                .HasForeignKey(pt => pt.EducationalBuildingIdTo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HourOfSemesterPeriod>()
                .HasOne(x => x.Period)
                .WithMany(x => x.HourOfSemesterPeriods)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public virtual DbSet<Auditorium> Auditoriums { get; set; }

        public virtual DbSet<EducationalBuilding> EducationalBuildings { get; set; }
        
        public virtual DbSet<TransitionTime> TransitionTimes { get; set; }

        public virtual DbSet<TypeOfAudience> TypeOfAudiences { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<TeacherDepartment> TeacherDepartments { get; set; }

        public virtual DbSet<ClassTime> ClassTimes { get; set; }

        public virtual DbSet<Schedule> Schedules { get; set; }

        public virtual DbSet<TypeOfDepartment> TypeOfDepartments { get; set; }

        public virtual DbSet<TypeOfClass> TypeOfClasses { get; set; }

        public virtual DbSet<Discipline> Disciplines { get; set; }

        public virtual DbSet<Faculty> Faculties { get; set; }

        public virtual DbSet<Specialty> Specialties { get; set; }

        public virtual DbSet<StudyGroup> StudyGroups { get; set; }

        public virtual DbSet<Flow> Flows { get; set; }

        public virtual DbSet<FlowStudyGroup> FlowStudyGroups { get; set; }

        public virtual DbSet<AcademicYear> AcademicYears { get; set; }

        public virtual DbSet<Semester> Semesters { get; set; }

        public virtual DbSet<Period> Periods { get; set; }

        public virtual DbSet<Curriculum> Curriculums { get; set; }

        public virtual DbSet<HourOfSemester> HourOfSemesters { get; set; }

        public virtual DbSet<HourOfSemesterRecord> HourOfSemesterRecords { get; set; }

        public virtual DbSet<HourOfSemesterPeriod> HourOfSemesterPeriods { get; set; }

        public virtual DbSet<HourOfSemesterAuditorium> HourOfSemesterAuditoriums { get; set; }
    }
}