using ScheduleModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleModel
{
    //расписание

    public class Schedule
    {
        public Guid Id { get; set; }

        public Guid PeriodId { get; set; } //период

        public DayOfTheWeek? DayOfTheWeek { get; set; } //день недели
        
        [Required]
        public int NumberWeeks { get; set; } //номер недели

        [Required]
        public string Type { get; set; } //тип записи (занятие, аудитория, преподаватель)

        public Guid? AuditoriumId { get; set; }

        public Guid? ClassTimeId { get; set; }

        public Guid? StudyGroupId { get; set; } //группа

        public int? Subgroups { get; set; } //подгруппа

        public Guid? TeacherId { get; set; } //учитель

        public virtual Auditorium Auditorium { get; set; }

        public virtual ClassTime ClassTime { get; set; }

        public virtual StudyGroup StudyGroup { get; set; }

        public virtual Period Period { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
