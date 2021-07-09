using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// тип занятия
	/// </summary>
	public class TypeOfClass : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string AbbreviatedTitle { get; set; }

        [ForeignKey("TypeOfClassId")]
        public virtual List<Curriculum> Curriculums { get; set; }

        [ForeignKey("TypeOfClassId")]
        public virtual List<LoadTeacher> LoadTeachers { get; set; }
    }
}