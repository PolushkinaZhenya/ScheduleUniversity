using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //учебная группа

    public class StudyGroup
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Course { get; set; }

        [Required]
        public int NumderStudents { get; set; }

        [Required]
        public int NumderSubgroups { get; set; }

        public Guid SpecialtyId { get; set; }

        public TypeEducation TypeEducation { get; set; }

        public FormEducation FormEducation { get; set; }

        public virtual Specialty Specialty { get; set; }

        [ForeignKey("StudyGroupId")]
        public virtual List<Schedule> Schedules { get; set; }

        [ForeignKey("StudyGroupId")]
        public virtual List<FlowStudyGroup> FlowStudyGroups { get; set; }

        [ForeignKey("StudyGroupId")]
        public virtual List<Curriculum> Curriculums { get; set; }
    }
}
