using ScheduleModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// время пар
	/// </summary>
	public class ClassTime : BaseEntity
    {
        [Required]
        public int Number { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [ForeignKey("ClassTimeId")]
        public virtual List<Schedule> Schedules { get; set; }
    }
}