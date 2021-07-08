using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class LoadTeacherAuditoriumViewModel
    {
        [Column(title: "id", visible: false)]
        public Guid Id { get; set; }

        public Guid LoadTeacherId { get; set; }
        
        public Guid AuditoriumId { get; set; }

        [Column(title: "Аудитория", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string AuditoriumTitle { get; set; }

        public int Priority { get; set; }
    }
}