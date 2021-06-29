using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class ClassTimeBindingModel : AdditionalReferenceBindingModel
    {
        public int Number { get; set; }
        
        public TimeSpan StartTime { get; set; }
        
        public TimeSpan EndTime { get; set; }
    }
}