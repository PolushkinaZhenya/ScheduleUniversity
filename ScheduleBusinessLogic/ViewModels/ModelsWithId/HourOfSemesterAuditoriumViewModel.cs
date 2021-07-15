using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class HourOfSemesterAuditoriumViewModel : BaseViewModel
    {
        public Guid HourOfSemesterRecordId { get; set; }
        
        public Guid AuditoriumId { get; set; }

        [Column(title: "Аудитория", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string AuditoriumTitle { get; set; }

        public int Priority { get; set; }
    }
}