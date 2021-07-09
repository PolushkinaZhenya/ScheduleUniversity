using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class SemesterSearchModel : BaseSearchModel
	{
		public string Title { get; set; }

		public Guid? AcademicYearId { get; set; }
	}
}