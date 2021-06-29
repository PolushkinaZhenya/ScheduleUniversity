using Microsoft.EntityFrameworkCore;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using ScheduleDatabaseImplementations;
using ScheduleDatabaseImplementations.Implementations;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	static class Program
    {
        public static readonly string DbType = "DbType";
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            while(!CheckConnectToBD(GetConnectionString(), ReadAppSettingConfig(DbType)))
			{
                var form = new FormConfiguration();
                if(form.ShowDialog() == DialogResult.Cancel)
				{
                    return;
				}
			}
            BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(DependencyManager.Instance.Resolve<FormMain>());
        }

        public static void BuildUnityContainer()
        {
            DependencyManager.Instance.RegisterInstance(GetOptions(GetConnectionString(), ReadAppSettingConfig(DbType)));
            DependencyManager.Instance.RegisterType<IAdditionalReference<TypeOfAudienceBindingModel, TypeOfAudienceViewModel>, TypeOfAudienceServiceDB>();
            DependencyManager.Instance.RegisterType<IAdditionalReference<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel>, TypeOfDepartmentServiceDB>();
            DependencyManager.Instance.RegisterType<IAdditionalReference<TypeOfClassBindingModel, TypeOfClassViewModel>, TypeOfClassServiceDB>();
            //DependencyManager.Instance.RegisterType<IDepartmentService, DepartmentServiceDB>();
            //DependencyManager.Instance.RegisterType<IEducationalBuildingService, EducationalBuildingServiceDB>();
            //DependencyManager.Instance.RegisterType<ITransitionTimeService, TransitionTimeServiceDB>();
            //DependencyManager.Instance.RegisterType<IAuditoriumService, AuditoriumServiceDB>();
            //DependencyManager.Instance.RegisterType<IClassTimeService, ClassTimeServiceDB>();
            //DependencyManager.Instance.RegisterType<ITeacherService, TeacherServiceDB>();
            //DependencyManager.Instance.RegisterType<IDisciplineService, DisciplineServiceDB>();
            //DependencyManager.Instance.RegisterType<IFacultyService, FacultyServiceDB>();
            //DependencyManager.Instance.RegisterType<ISpecialtyService, SpecialtyServiceDB>();
            //DependencyManager.Instance.RegisterType<IStudyGroupService, StudyGroupServiceDB>();
            //DependencyManager.Instance.RegisterType<IFlowService, FlowServiceDB>();
            //DependencyManager.Instance.RegisterType<IAcademicYearService, AcademicYearServiceDB>();
            //DependencyManager.Instance.RegisterType<ISemesterService, SemesterServiceDB>();
            //DependencyManager.Instance.RegisterType<IPeriodService, PeriodServiceDB>();
            //DependencyManager.Instance.RegisterType<ICurriculumService, CurriculumServiceDB>();
            //DependencyManager.Instance.RegisterType<IScheduleService, ScheduleServiceDB>();
            //DependencyManager.Instance.RegisterType<ILoadTeacherService, LoadTeacherServiceDB>();
            //DependencyManager.Instance.RegisterType<IRecordService, RecordServiceDB>();
            //DependencyManager.Instance.RegisterType<ISyncWith1C, SyncWith1C>();
        }

        private static DbContextOptions<ScheduleDbContext> GetOptions(string connectionString, string dbType)
		{

            var optionsBuilder = new DbContextOptionsBuilder<ScheduleDbContext>();
            switch (dbType)
            {
                case "MSSQL":
                    optionsBuilder.UseSqlServer(@connectionString);
                    break;
                case "Postgresql":
                    optionsBuilder.UseNpgsql(@connectionString);
                    break;
            }
            return optionsBuilder.Options;
        }

        public static string GetConnectionString() => ConfigurationManager.ConnectionStrings["AbstractDbContext"]?.ConnectionString;

        public static void SetConnectionString(string connectionString)
		{
            if (!string.IsNullOrEmpty(connectionString))
            {
                ConfigurationManager.ConnectionStrings["AbstractDbContext"].ConnectionString = connectionString;
            }
        }

        public static bool CheckConnectToBD(string connectionString, string dbType)
        {
            using var dbContext = new ScheduleDbContext(GetOptions(connectionString, dbType));
            return dbContext.Database.CanConnect();
        }

        public static string ReadAppSettingConfig(string configName)
		{
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    throw new ConfigurationErrorsException("AppSettings is empty");
                }
                else
                {
                    return appSettings[configName];
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                ShowError(ex.Message, "Ошибка получения настроек");
                return null;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message, "Общая ошибка");
                return null;
            }
        }

        public static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException ex)
            {
                ShowError(ex.Message, "Ошибка получения настроек");
            }
        }

		public static void ShowError(string message, string caption) => MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowInfo(string message, string caption) => MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
