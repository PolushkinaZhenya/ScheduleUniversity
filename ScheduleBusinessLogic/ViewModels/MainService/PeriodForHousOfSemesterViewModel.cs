using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.ViewModels
{
	public class PeriodForHousOfSemesterViewModel
	{
		public Guid HousOfSemesterId { get; set; }

		public string DisciplineTitle { get; set; }

		public string TeacherShortName { get; set; }

		public List<string> Flows { get; set; }

		public int? SubgroupNumber { get; set; }

		public int TotalHours { get; set; }

		public Guid HourOfSemesterPeriodId { get; set; }

		public  int HoursFirstWeek { get; set; }

		public int HoursSecondWeek { get; set; }

		public string Auditoriums { get; set; }
	}
}