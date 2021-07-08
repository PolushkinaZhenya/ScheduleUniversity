using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class LoadTeacherAuditoriumBindingModel
    {
        public Guid Id { get; set; }

        public Guid LoadTeacherId { get; set; }

        public Guid AuditoriumId { get; set; }

        public int Priority { get; set; }
    }
}