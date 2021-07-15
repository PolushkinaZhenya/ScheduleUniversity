using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class HourOfSemesterSearchModel : BaseSearchModel
    {
        public Guid? SemesterId { get; set; }

        public Guid? PeriodId { get; set; }

        public Guid? DisciplineId { get; set; }

        public Guid? StudyGroupId { get; set; }

        public Guid? TeacherId { get; set; }

        public Guid? AuditoriumId { get; set; }

        public Guid? TypeOfClassId { get; set; }

        public string Reporting { get; set; }

        public string Wishes { get; set; }
    }
}