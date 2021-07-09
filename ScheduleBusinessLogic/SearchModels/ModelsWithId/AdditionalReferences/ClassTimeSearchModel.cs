using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class ClassTimeSearchModel : BaseSearchModel
	{
		public int? Number { get; set; }

		public TimeSpan? StartTime { get; set; }

		public TimeSpan? EndTime { get; set; }
	}
}