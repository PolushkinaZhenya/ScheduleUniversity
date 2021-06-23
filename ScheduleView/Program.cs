using ScheduleImplementations.Implementations;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.Interfaces.AdditionalReferences;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Windows.Forms;

namespace ScheduleView
{
	static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(DependencyManager.Instance.Resolve<FormMain>());
        }

        public static void BuildUnityContainer()
        {
            DependencyManager.Instance.RegisterType<IAdditionalReference<TypeOfAudienceBindingModel, TypeOfAudienceViewModel>, TypeOfAudienceServiceDB>();
            DependencyManager.Instance.RegisterType<IAdditionalReference<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel>, TypeOfDepartmentServiceDB>();
            DependencyManager.Instance.RegisterType<IAdditionalReference<TypeOfClassBindingModel, TypeOfClassViewModel>, TypeOfClassServiceDB>();
            DependencyManager.Instance.RegisterType<IDepartmentService, DepartmentServiceDB>();
            DependencyManager.Instance.RegisterType<IEducationalBuildingService, EducationalBuildingServiceDB>();
            DependencyManager.Instance.RegisterType<ITransitionTimeService, TransitionTimeServiceDB>();
            DependencyManager.Instance.RegisterType<IAuditoriumService, AuditoriumServiceDB>();
            DependencyManager.Instance.RegisterType<IClassTimeService, ClassTimeServiceDB>();
            DependencyManager.Instance.RegisterType<ITeacherService, TeacherServiceDB>();
            DependencyManager.Instance.RegisterType<IDisciplineService, DisciplineServiceDB>();
            DependencyManager.Instance.RegisterType<IFacultyService, FacultyServiceDB>();
            DependencyManager.Instance.RegisterType<ISpecialtyService, SpecialtyServiceDB>();
            DependencyManager.Instance.RegisterType<IStudyGroupService, StudyGroupServiceDB>();
            DependencyManager.Instance.RegisterType<IFlowService, FlowServiceDB>();
            DependencyManager.Instance.RegisterType<IAcademicYearService, AcademicYearServiceDB>();
            DependencyManager.Instance.RegisterType<ISemesterService, SemesterServiceDB>();
            DependencyManager.Instance.RegisterType<IPeriodService, PeriodServiceDB>();
            DependencyManager.Instance.RegisterType<ICurriculumService, CurriculumServiceDB>();
            DependencyManager.Instance.RegisterType<IScheduleService, ScheduleServiceDB>();
            DependencyManager.Instance.RegisterType<ILoadTeacherService, LoadTeacherServiceDB>();
            DependencyManager.Instance.RegisterType<IRecordService, RecordServiceDB>();
            DependencyManager.Instance.RegisterType<ISyncWith1C, SyncWith1C>();
        }
    }
}
