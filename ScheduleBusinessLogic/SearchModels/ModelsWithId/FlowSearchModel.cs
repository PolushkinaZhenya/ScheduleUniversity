using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class FlowSearchModel : BaseSearchModel
	{
		public string Title { get; set; }

		public Guid? StudentGroupId { get; set; }
	}
}