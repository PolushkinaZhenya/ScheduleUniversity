using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class DepartmentSearchModel : BaseSearchModel
	{
		public string Title { get; set; }

		public Guid? TypeOfDepartmentId { get; set; }
	}
}