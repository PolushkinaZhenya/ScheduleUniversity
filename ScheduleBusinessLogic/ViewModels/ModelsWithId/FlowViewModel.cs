using ScheduleBusinessLogic.Attributes;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.ViewModels
{
	public class FlowViewModel : BaseViewModel
    {
        [Column(title: "Название", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }

        public List<FlowStudyGroupViewModel> FlowStudyGroups { get; set; }
    }
}