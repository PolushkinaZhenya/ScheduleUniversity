using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class AuditoriumBindingModel : BaseBindingModel
    {
        public string Number { get; set; }
        
        public int Capacity { get; set; }

        public Guid EducationalBuildingId { get; set; }

        public Guid TypeOfAudienceId { get; set; }

        public Guid DepartmentId { get; set; }
    }
}