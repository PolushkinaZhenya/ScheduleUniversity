using System.Collections.Generic;

namespace ScheduleBusinessLogic.BindingModels
{
	public class FlowBindingModel : BaseBindingModel
    {
        public string Title { get; set; }

        public List<FlowStudyGroupBindingModel> FlowStudyGroups { get; set; }
    }
}