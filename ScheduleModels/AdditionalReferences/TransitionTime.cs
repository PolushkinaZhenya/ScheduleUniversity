using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleModels
{
	//время перехода между корпусами

	public class TransitionTime
    {
        public Guid Id { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        public Guid EducationalBuildingIdFrom { get; set; }

        public Guid EducationalBuildingIdTo { get; set; }

        public virtual EducationalBuilding EducationalBuildingFrom { get; set; }

        public virtual EducationalBuilding EducationalBuildingTo { get; set; }
    }
}