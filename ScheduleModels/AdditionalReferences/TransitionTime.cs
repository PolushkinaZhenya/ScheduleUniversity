using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleModels
{
	//время перехода между корпусами

	public class TransitionTime : BaseEntity
    {
        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        public Guid EducationalBuildingIdFrom { get; set; }

        [Required]
        public Guid EducationalBuildingIdTo { get; set; }

        public virtual EducationalBuilding EducationalBuildingFrom { get; set; }

        public virtual EducationalBuilding EducationalBuildingTo { get; set; }
    }
}