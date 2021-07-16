using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class PeriodForHousOfSemesterBindingModel
	{
		public Guid StudyGroupId { get; set; }

		public Guid TypeOfClassId { get; set; }

		public Guid PeriodId { get; set; }
	}
}