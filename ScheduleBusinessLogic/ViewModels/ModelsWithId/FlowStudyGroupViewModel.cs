using System;
using System.ComponentModel;

namespace ScheduleBusinessLogic.ViewModels
{
	public class FlowStudyGroupViewModel : BaseViewModel
    {
        public Guid FlowId { get; set; }

        public Guid StudyGroupId { get; set; }
        [DisplayName("Группа")]
        public string StudyGroupTitle { get; set; }

        [DisplayName("Подгруппа")]
        public int? Subgroup { get; set; }
    }
}