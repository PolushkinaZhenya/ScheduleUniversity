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

        public Guid TypeOfClassId { get; set; }// дублируем тип занятия

        public virtual TypeOfClass TypeOfClass { get; set; }

        public Guid DisciplineId { get; set; }// дублируем предмет

        public virtual Discipline Discipline { get; set; }

        public Guid TeacherId { get; set; } // дублируем преподавателя

        public virtual Teacher Teacher { get; set; }

        public Guid StudyGroupId { get; set; } // дублируем группу

        public virtual StudyGroup StudyGroup { get; set; }

        public int? SubgroupNumber { get; set; } // дублируем номер подгруппы

        public Guid? FlowId { get; set; } // дублируем поток

        public virtual Flow Flow { get; set; }

        public virtual HourOfSemesterPeriod HourOfSemesterPeriod { get; set; }
    }
}
