using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ScheduleBusinessLogic.ViewModels
{
	public class FlowViewModel : BaseViewModel
    {
        [DisplayName("Название")]
        public string Title { get; set; }

        public bool FlowAutoCreation { get; set; }

        public List<FlowStudyGroupViewModel> FlowStudyGroups { get; set; }
    }
}