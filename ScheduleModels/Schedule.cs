using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleModels
{
	/// <summary>
	/// расписание
	/// </summary>

	public class Schedule : BaseEntity
    {
        public Guid HourOfSemesterPeriodId { get; set; } //период

        [Required]
        public string Type { get; set; } //тип записи (занятие, аудитория, преподаватель)
        
        [Required]
        public int NumberWeeks { get; set; } //номер недели

        public DayOfTheWeek? DayOfTheWeek { get; set; } //день недели

        public Guid? ClassTimeId { get; set; } // пара

        public virtual ClassTime ClassTime { get; set; }

        public Guid? AuditoriumId { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public virtual HourOfSemesterPeriod HourOfSemesterPeriod { get; set; }
    }
}
