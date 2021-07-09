using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// учебный год
	/// </summary>
	public class AcademicYear : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [ForeignKey("AcademicYearId")]
        public virtual List<Semester> Semesters { get; set; }
    }
}