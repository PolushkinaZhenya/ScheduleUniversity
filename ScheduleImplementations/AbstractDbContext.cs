using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleModel;
using System.Data.Entity;

namespace ScheduleImplementations
{
    public class AbstractDbContext : DbContext
    {
        public AbstractDbContext() : base("AbstractDbContext")
        {
            //настройки конфигурации для entity            
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
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
        
    }
}
