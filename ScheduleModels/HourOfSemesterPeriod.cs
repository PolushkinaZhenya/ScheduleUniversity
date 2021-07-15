using System;
using System.ComponentModel.DataAnnotations;

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
    }
}