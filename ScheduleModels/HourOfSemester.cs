using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// расчасовка
	/// </summary>
	public class HourOfSemester : BaseEntity
    {
        [Required]
        public Guid DisciplineId { get; set; }

        public virtual Discipline Discipline { get; set; }

        [Required]
        public Guid StudyGroupId { get; set; }

        public virtual StudyGroup StudyGroup { get; set; }

        [Required]
        public Guid SemesterId { get; set; }

        public virtual Semester Semester { get; set; }

        public string Reporting { get; set; }

        public string Wishes { get; set; }

        [ForeignKey("HourOfSemesterId")]
        public virtual List<HourOfSemesterRecord> HourOfSemesterRecords { get; set; }
    }
}