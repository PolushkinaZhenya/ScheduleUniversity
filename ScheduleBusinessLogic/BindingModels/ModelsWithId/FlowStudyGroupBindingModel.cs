using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class FlowStudyGroupBindingModel : BaseBindingModel
    {
        public Guid FlowId { get; set; }

        public Guid StudyGroupId { get; set; }

        public int? Subgroup { get; set; }
    }
}