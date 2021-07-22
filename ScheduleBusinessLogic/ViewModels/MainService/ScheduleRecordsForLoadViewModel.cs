using System.Collections.Generic;

namespace ScheduleBusinessLogic.ViewModels
{
	public class ScheduleRecordsForLoadViewModel
	{
		public int NumberWeek { get; set; }

		public List<ScheduleViewModel> StudyGroupSubGroupLoads { get; set; }

		public List<ScheduleViewModel> TeachersLoads { get; set; }

		public List<ScheduleViewModel> AuditoriumLoads { get; set; }

		public List<ScheduleViewModel> FlowLoads { get; set; }
	}
}