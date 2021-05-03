using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //расписание

    public class Schedule
    {
        public Guid Id { get; set; }

        public DayOfTheWeek? DayOfTheWeek { get; set; } //день недели

        public int? Subgroups { get; set; } //подгруппа

        [Required]
        public int NumberWeeks { get; set; } //номер недели

        public string Type { get; set; } //тип записи (занятие, сессия)

        public Guid? AuditoriumId { get; set; }

        public Guid? ClassTimeId { get; set; }

        public Guid StudyGroupId { get; set; }

        public Guid PeriodId { get; set; }

        public Guid LoadTeacherId { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public virtual ClassTime ClassTime { get; set; }

        public virtual StudyGroup StudyGroup { get; set; }

        public virtual Period Period { get; set; }

        public virtual LoadTeacher LoadTeacher { get; set; }
    }
}
