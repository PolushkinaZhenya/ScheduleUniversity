using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// учебная группа
	/// </summary>
	public class StudyGroup : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Guid SpecialtyId { get; set; }

        public virtual Specialty Specialty { get; set; }

        public TypeEducation TypeEducation { get; set; }

        public FormEducation FormEducation { get; set; }

        [Required]
        public int Course { get; set; }

        [Required]
        public int GroupNumber { get; set; }

        [Required]
        public int NumderStudents { get; set; }

        [ForeignKey("StudyGroupId")]
        public virtual List<FlowStudyGroup> FlowStudyGroups { get; set; }

        [ForeignKey("StudyGroupId")]
        public virtual List<Curriculum> Curriculums { get; set; }

        [ForeignKey("StudyGroupId")]
        public virtual List<HourOfSemester> HourOfSemesters { get; set; }

        [ForeignKey("StudyGroupId")]
        public virtual List<Schedule> Schedules { get; set; }
    }
}