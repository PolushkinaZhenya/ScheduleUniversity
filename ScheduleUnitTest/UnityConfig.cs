using ScheduleDatabaseImplementations.Implementations;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using System;
using Unity;
using Unity.Lifetime;

namespace ScheduleUnitTest
{
	public static class UnityConfig
    {
        #region Unity Container 
        private static Lazy<IUnityContainer> container =
        new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            //var currentContainer = new UnityContainer();

            container.RegisterType<IAdditionalReference<TypeOfAudienceBindingModel, TypeOfAudienceViewModel>, TypeOfAudienceServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IAdditionalReference<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel>, TypeOfDepartmentServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IAdditionalReference<TypeOfClassBindingModel, TypeOfClassViewModel>, TypeOfClassServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IDepartmentService, DepartmentServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IEducationalBuildingService, EducationalBuildingServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransitionTimeService, TransitionTimeServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuditoriumService, AuditoriumServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IClassTimeService, ClassTimeServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<ITeacherService, TeacherServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IDisciplineService, DisciplineServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IFacultyService, FacultyServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<ISpecialtyService, SpecialtyServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IStudyGroupService, StudyGroupServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IFlowService, FlowServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IAcademicYearService, AcademicYearServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<ISemesterService, SemesterServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IPeriodService, PeriodServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<ICurriculumService, CurriculumServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IScheduleService, ScheduleServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<ILoadTeacherService, LoadTeacherServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IRecordService, RecordServiceDB>(new HierarchicalLifetimeManager());

            //return currentContainer;
        }

    }
}
