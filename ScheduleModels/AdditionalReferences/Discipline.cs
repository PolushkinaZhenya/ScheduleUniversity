using ScheduleModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// дисциплина
	/// </summary>
	public class Discipline
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AbbreviatedTitle { get; set; }

        [ForeignKey("DisciplineId")]
        public virtual List<Curriculum> Curriculums { get; set; }

        [ForeignKey("DisciplineId")]
        public virtual List<LoadTeacher> LoadTeachers { get; set; }
    }
}