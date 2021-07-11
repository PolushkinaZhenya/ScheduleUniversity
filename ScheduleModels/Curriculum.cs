using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleModels
{
    /// <summary>
    /// учебный план
    /// </summary>
    public class Curriculum : BaseEntity
    {
        [Required]
        public int NumderOfHours { get; set; }

        public Guid DisciplineId { get; set; }

        public virtual Discipline Discipline { get; set; }

        public Guid StudyGroupId { get; set; }

        public virtual StudyGroup StudyGroup { get; set; }

        public Guid TypeOfClassId { get; set; }

        public virtual TypeOfClass TypeOfClass { get; set; }

        public Guid SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
    }
}