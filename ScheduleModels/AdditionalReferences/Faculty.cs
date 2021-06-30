using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// факультет
	/// </summary>
	public class Faculty
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("FacultyId")]
        public virtual List<Specialty> Specialties { get; set; }
    }
}