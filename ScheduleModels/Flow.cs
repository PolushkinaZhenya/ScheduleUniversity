using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// поток
	/// </summary>
	public class Flow : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [ForeignKey("FlowId")]
        public virtual List<FlowStudyGroup> FlowStudyGroups { get; set; }

        [ForeignKey("FlowId")]
        public virtual List<HourOfSemesterRecord> HourOfSemesterRecords { get; set; }
    }
}