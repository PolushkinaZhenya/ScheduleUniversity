using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class CreateDuplicateByHOSBindingModel
	{
		public Guid StudyGroupId { get; set; }

		public Guid HousOfSemesterId { get; set; }
	}
}