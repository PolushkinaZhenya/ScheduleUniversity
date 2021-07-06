using Microsoft.EntityFrameworkCore;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using ScheduleDatabaseImplementations;
using ScheduleDatabaseImplementations.Implementations;
using System;
using System.Configuration;
using System.Text;
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
            DependencyManager.Instance.RegisterType<IAdditionalReference<EducationalBuildingBindingModel, EducationalBuildingViewModel>, EducationalBuildingServiceDB>();
			DependencyManager.Instance.RegisterType<IAdditionalReference<TransitionTimeBindingModel, TransitionTimeViewModel>, TransitionTimeServiceDB>();
			DependencyManager.Instance.RegisterType<IAdditionalReference<ClassTimeBindingModel, ClassTimeViewModel>, ClassTimeServiceDB>();
			DependencyManager.Instance.RegisterType<IAdditionalReference<AcademicYearBindingModel, AcademicYearViewModel>, AcademicYearServiceDB>();
			DependencyManager.Instance.RegisterType<IAdditionalReference<SemesterBindingModel, SemesterViewModel>, SemesterServiceDB>();
            DependencyManager.Instance.RegisterType<IAdditionalReference<PeriodBindingModel, PeriodViewModel>, PeriodServiceDB>();
            DependencyManager.Instance.RegisterType<IAdditionalReference<DepartmentBindingModel, DepartmentViewModel>, DepartmentServiceDB>();
            DependencyManager.Instance.RegisterType<IAdditionalReference<DisciplineBindingModel, DisciplineViewModel>, DisciplineServiceDB>();
			DependencyManager.Instance.RegisterType<IAdditionalReference<FacultyBindingModel, FacultyViewModel>, FacultyServiceDB>();
			DependencyManager.Instance.RegisterType<IAdditionalReference<SpecialtyBindingModel, SpecialtyViewModel>, SpecialtyServiceDB>();

			DependencyManager.Instance.RegisterType<IStudyGroupService, StudyGroupServiceDB>();
			DependencyManager.Instance.RegisterType<IAuditoriumService, AuditoriumServiceDB>();
			DependencyManager.Instance.RegisterType<ITeacherService, TeacherServiceDB>();
			DependencyManager.Instance.RegisterType<IFlowService, FlowServiceDB>();
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
            if (!dbContext.Database.CanConnect())
            {
                dbContext.Database.Migrate();
            }
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

        public static void ShowError(Exception ex, string caption)
        {
            var sb = new StringBuilder(ex.Message);
            while(ex.InnerException != null)
			{
                ex = ex.InnerException;
                sb.AppendLine(ex.Message);
			}

            MessageBox.Show(sb.ToString(), caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(string message, string caption) => MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

		public static DialogResult ShowQuestion(string message, string caption = "Вопрос") => MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	}
}
