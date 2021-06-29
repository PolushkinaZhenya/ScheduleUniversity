using ScheduleModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
    /// <summary>
    /// период
    /// </summary>
    public class Period
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public Guid SemesterId { get; set; }

        public virtual Semester Semester { get; set; }

        [ForeignKey("PeriodId")]
        public virtual List<Schedule> Schedules { get; set; }

        [ForeignKey("PeriodId")]
        public virtual List<LoadTeacherPeriod> LoadTeacherPeriods { get; set; }
    }
}