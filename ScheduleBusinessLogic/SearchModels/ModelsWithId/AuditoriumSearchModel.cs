using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class AuditoriumSearchModel : BaseSearchModel
    {
        public string? Number { get; set; }

        public int? Capacity { get; set; }

        public Guid? EducationalBuildingId { get; set; }

        public Guid? TypeOfAudienceId { get; set; }

        public Guid? DepartmentId { get; set; }
    }
}