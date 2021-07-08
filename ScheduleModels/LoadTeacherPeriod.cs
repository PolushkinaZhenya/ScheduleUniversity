using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleModels
{
	/// <summary>
	/// связь расчасовка - период
	/// </summary>
	public class LoadTeacherPeriod
    {
        public Guid Id { get; set; }

        public Guid LoadTeacherId { get; set; }

        public Guid PeriodId { get; set; }

        [Required]
        public int TotalHours { get; set; }

        [Required]
        public int HoursFirstWeek { get; set; }

        [Required]
        public int HoursSecondWeek { get; set; }

        public virtual LoadTeacher LoadTeacher { get; set; }

        public virtual Period Period { get; set; }
    }
}