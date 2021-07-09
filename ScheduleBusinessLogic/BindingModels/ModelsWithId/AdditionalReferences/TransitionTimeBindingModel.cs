using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class TransitionTimeBindingModel : BaseBindingModel
    {
        public TimeSpan Time { get; set; }

        public Guid EducationalBuildingIdFrom { get; set; }

        public Guid EducationalBuildingIdTo { get; set; }
    }
}