using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class LoadTeacherAuditoriumBindingModel : BaseBindingModel
    {
        public Guid LoadTeacherId { get; set; }

        public Guid AuditoriumId { get; set; }

        public int Priority { get; set; }
    }
}