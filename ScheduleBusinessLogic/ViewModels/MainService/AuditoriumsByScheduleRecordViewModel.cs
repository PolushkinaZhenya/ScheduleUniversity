using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.ViewModels
{
	public class AuditoriumsByScheduleRecordViewModel
	{
		public List<(Guid Id, string Number)> Auditoriums { get; set; }
	}
}