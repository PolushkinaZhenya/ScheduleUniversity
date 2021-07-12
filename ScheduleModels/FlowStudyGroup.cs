using System;

namespace ScheduleModels
{
	/// <summary>
	/// связь поток - группа
	/// </summary>
	public class FlowStudyGroup : BaseEntity
    {
        public Guid FlowId { get; set; }

        public Guid StudyGroupId { get; set; }

        public int? Subgroup { get; set; }

        public virtual Flow Flow { get; set; }

        public virtual StudyGroup StudyGroup { get; set; }
    }
}