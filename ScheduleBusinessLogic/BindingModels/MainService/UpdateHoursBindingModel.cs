using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class UpdateHoursBindingModel
	{
		public Guid HourOfSemesterPeriodId { get; set; }

		public int FirstWeekCountLessons { get; set; }

		public int SecondWeekCountLessons { get; set; }
	}
}