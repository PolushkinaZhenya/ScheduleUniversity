using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class LoadTeacherAuditoriumViewModel : BaseViewModel
    {
        public Guid LoadTeacherId { get; set; }
        
        public Guid AuditoriumId { get; set; }

        [Column(title: "Аудитория", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string AuditoriumTitle { get; set; }

        public int Priority { get; set; }
    }
}