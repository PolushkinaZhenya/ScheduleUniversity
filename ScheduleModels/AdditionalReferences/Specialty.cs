using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// специальность
	/// </summary>
	public class Specialty : BaseEntity
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AbbreviatedTitle { get; set; }

        [Required]
        public Guid FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }

        [ForeignKey("SpecialtyId")]
        public virtual List<StudyGroup> StudyGroups { get; set; }
    }
}