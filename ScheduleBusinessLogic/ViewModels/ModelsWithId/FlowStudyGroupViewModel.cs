using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class FlowStudyGroupViewModel : BaseViewModel
    {
        public Guid FlowId { get; set; }

        public Guid StudyGroupId { get; set; }

        [Column(title: "Группа", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string StudyGroupTitle { get; set; }

        [Column(title: "Подгруппа", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int? Subgroup { get; set; }
    }
}