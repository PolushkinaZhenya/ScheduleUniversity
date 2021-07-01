using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ScheduleBusinessLogic.ViewModels
{
	public class FlowViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Название")]
        public string Title { get; set; }

        public bool FlowAutoCreation { get; set; }

        public List<FlowStudyGroupViewModel> FlowStudyGroups { get; set; }
    }
}