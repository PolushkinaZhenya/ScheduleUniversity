using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.BindingModels
{
	public class FlowBindingModel
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public bool FlowAutoCreation { get; set; }

        public List<FlowStudyGroupBindingModel> FlowStudyGroups { get; set; }
    }
}