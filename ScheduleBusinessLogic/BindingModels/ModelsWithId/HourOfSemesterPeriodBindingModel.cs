using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class HourOfSemesterPeriodBindingModel : BaseBindingModel
    {
        public Guid HourOfSemesterRecordId { get; set; }

        public Guid PeriodId { get; set; }

        public int HoursFirstWeek { get; set; }
        
        public int HoursSecondWeek { get; set; }
    }
}