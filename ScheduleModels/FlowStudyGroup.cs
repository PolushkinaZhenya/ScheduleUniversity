using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleModels
{
	/// <summary>
	/// связь поток - группа
	/// </summary>
	public class FlowStudyGroup : BaseEntity
    {
        [Required]
        public Guid FlowId { get; set; }

        [Required]
        public Guid StudyGroupId { get; set; }

        public int? Subgroup { get; set; }

        public virtual Flow Flow { get; set; }

        public virtual StudyGroup StudyGroup { get; set; }
    }
}