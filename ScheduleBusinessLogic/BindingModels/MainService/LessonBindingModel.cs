using ScheduleModels;
using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class LessonBindingModel
	{
		public Guid ScheduleId { get; set; }

		public DayOfTheWeek DayOfTheWeek { get; set; }

		public Guid ClassTimeId { get; set; }

		public Guid AuditoriumId { get; set; }

		public bool SetToFreeAuditorium { get; set; }

		public bool ForcedSet { get; set; }
	}
}