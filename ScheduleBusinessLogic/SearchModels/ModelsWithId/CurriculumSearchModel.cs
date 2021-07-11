using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class CurriculumSearchModel : BaseSearchModel
    {
        public Guid? DisciplineId { get; set; }

        public Guid? StudyGroupId { get; set; }

        public Guid? TypeOfClassId { get; set; }

        public Guid? SemesterId { get; set; }

        public Guid? AcademicYearId { get; set; }

        public int? NumderOfHours { get; set; }
    }
}