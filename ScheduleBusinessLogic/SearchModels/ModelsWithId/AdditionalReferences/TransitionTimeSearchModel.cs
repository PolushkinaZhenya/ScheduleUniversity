using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class TransitionTimeSearchModel : BaseSearchModel
	{
		public TimeSpan? Time { get; set; }

		public Guid? EducationalBuildingIdFrom { get; set; }

		public Guid? EducationalBuildingIdTo { get; set; }
	}
}