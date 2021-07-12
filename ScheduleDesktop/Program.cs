using Microsoft.EntityFrameworkCore;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
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

        public static readonly string CurrentPeriod = "CurrentPeriod";
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

			DependencyManager.Instance.RegisterType<IBaseService<TypeOfAudienceBindingModel, TypeOfAudienceViewModel, TypeOfAudienceSearchModel>, TypeOfAudienceServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel, TypeOfDepartmentSearchModel>, TypeOfDepartmentServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<TypeOfClassBindingModel, TypeOfClassViewModel, TypeOfClassSearchModel>, TypeOfClassServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<EducationalBuildingBindingModel, EducationalBuildingViewModel, EducationalBuildingSearchModel>, EducationalBuildingServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<TransitionTimeBindingModel, TransitionTimeViewModel, TransitionTimeSearchModel>, TransitionTimeServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel>, ClassTimeServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<DepartmentBindingModel, DepartmentViewModel, DepartmentSearchModel>, DepartmentServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<DisciplineBindingModel, DisciplineViewModel, DisciplineSearchModel>, DisciplineServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<FacultyBindingModel, FacultyViewModel, FacultySearchModel>, FacultyServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<SpecialtyBindingModel, SpecialtyViewModel, SpecialtySearchModel>, SpecialtyServiceDB>();

			DependencyManager.Instance.RegisterType<IBaseService<AcademicYearBindingModel, AcademicYearViewModel, AcademicYearSearchModel>, AcademicYearServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<SemesterBindingModel, SemesterViewModel, SemesterSearchModel>, SemesterServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<PeriodBindingModel, PeriodViewModel, PeriodSearchModel>, PeriodServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<CurriculumBindingModel, CurriculumViewModel, CurriculumSearchModel>, CurriculumServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel>, StudyGroupServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel>, AuditoriumServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<TeacherBindingModel, TeacherViewModel, TeacherSearchModel>, TeacherServiceDB>();
			DependencyManager.Instance.RegisterType<IBaseService<FlowBindingModel, FlowViewModel, FlowSearchModel>, FlowServiceDB>();
			DependencyManager.Instance.RegisterType<ILoadTeacherService, LoadTeacherServiceDB>();
            //DependencyManager.Instance.RegisterType<IScheduleService, ScheduleServiceDB>();
            //DependencyManager.Instance.RegisterType<IRecordService, RecordServiceDB>();
            //DependencyManager.Instance.RegisterType<ISyncWith1C, SyncWith1C>();

            DependencyManager.Instance.RegisterType<IMainService, MainService>();
        }

        public static DbContextOptions<ScheduleDbContext> GetOptions(string connectionString, string dbType)
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
