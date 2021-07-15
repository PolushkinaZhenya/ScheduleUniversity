using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.BindingModels
{
	public class HourOfSemesterRecordBindingModel : BaseBindingModel
	{
		public Guid HourOfSemesterId { get; set; }

		public Guid TypeOfClassId { get; set; }

		public Guid TeacherId { get; set; }

		public Guid? FlowId { get; set; }

		public int TotalHours { get; set; }

		public int? SubgroupNumber { get; set; }

		public List<HourOfSemesterPeriodBindingModel> HourOfSemesterPeriods { get; set; }

		public List<HourOfSemesterAuditoriumBindingModel> HourOfSemesterAuditoriums { get; set; }
	}
}