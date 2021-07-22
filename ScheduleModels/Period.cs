using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// период
	/// </summary>
	public class Period : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public Guid SemesterId { get; set; }

        public virtual Semester Semester { get; set; }

        [ForeignKey("PeriodId")]
        public virtual List<HourOfSemesterPeriod> HourOfSemesterPeriods { get; set; }
    }
}