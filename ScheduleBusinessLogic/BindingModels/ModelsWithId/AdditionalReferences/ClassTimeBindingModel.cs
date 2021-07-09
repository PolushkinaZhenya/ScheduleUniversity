using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class ClassTimeBindingModel : BaseBindingModel
    {
        public int Number { get; set; }
        
        public TimeSpan StartTime { get; set; }
        
        public TimeSpan EndTime { get; set; }
    }
}