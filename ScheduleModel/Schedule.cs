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
        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; } //день недели

        public int Subgroups { get; set; } //подгруппа

        [Required]
        public int NumberWeeks { get; set; } //номер недели

        public int AuditoriumId { get; set; }

        public int ClassTimeId { get; set; }

        public int TeacherId { get; set; }

        public int TypeOfClassId { get; set; }

        public int DisciplineId { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public virtual ClassTime ClassTime { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual TypeOfClass TypeOfClass { get; set; }

        public virtual Discipline Discipline { get; set; }
    }
}
