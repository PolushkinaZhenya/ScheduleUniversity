using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class HourOfSemesterAuditoriumBindingModel : BaseBindingModel
    {
        public Guid HourOfSemesterRecordId { get; set; }

        public Guid AuditoriumId { get; set; }

        public int Priority { get; set; }
    }
}