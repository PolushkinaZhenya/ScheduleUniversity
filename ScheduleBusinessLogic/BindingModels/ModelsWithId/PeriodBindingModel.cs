using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class PeriodBindingModel : BaseBindingModel
    {
        public string Title { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public Guid SemesterId { get; set; }
    }
}