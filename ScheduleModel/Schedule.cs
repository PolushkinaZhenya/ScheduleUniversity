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

        public DayOfWeek DayOfWeek { get; set; } //день недели

        public int Subgroups { get; set; } //подгруппа

        [Required]
        public int NumberWeeks { get; set; } //номер недели

        public Guid AuditoriumId { get; set; }

        public Guid ClassTimeId { get; set; }

        public Guid TeacherId { get; set; }

        public Guid TypeOfClassId { get; set; }

        public Guid DisciplineId { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public virtual ClassTime ClassTime { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual TypeOfClass TypeOfClass { get; set; }

        public virtual Discipline Discipline { get; set; }
    }
}
