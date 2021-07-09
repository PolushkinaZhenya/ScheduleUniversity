using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class LoadTeacherPeriodBindingModel : BaseBindingModel
    {
        public Guid LoadTeacherId { get; set; }

        public Guid PeriodId { get; set; }
        
        public int TotalHours { get; set; }

        public int HoursFirstWeek { get; set; }
        
        public int HoursSecondWeek { get; set; }
    }
}