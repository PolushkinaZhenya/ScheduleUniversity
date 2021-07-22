using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// связь расчасовка - период
	/// </summary>
	public class HourOfSemesterPeriod : BaseEntity
    {
        [Required]
        public Guid HourOfSemesterRecordId { get; set; }

        public virtual HourOfSemesterRecord HourOfSemesterRecord { get; set; }

        [Required]
        public Guid PeriodId { get; set; }

        public virtual Period Period { get; set; }

        [Required]
        public int HoursFirstWeek { get; set; }

        [Required]
        public int HoursSecondWeek { get; set; }

        [ForeignKey("HourOfSemesterPeriodId")]
        public virtual List<Schedule> Schedules { get; set; }
    }
}