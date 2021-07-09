using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// семестер
	/// </summary>
	public class Semester : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Guid AcademicYearId { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }

        [ForeignKey("SemesterId")]
        public virtual List<Period> Periods { get; set; }

        [ForeignKey("SemesterId")]
        public virtual List<Curriculum> Curriculums { get; set; }
    }
}