using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class PeriodSearchModel : BaseSearchModel
    {
        public string Title { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? SemesterId { get; set; }

        public Guid? AcademicYearId { get; set; }
    }
}