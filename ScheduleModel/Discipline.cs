using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //дисциплина

    public class Discipline
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AbbreviatedTitle { get; set; }

        [ForeignKey("DisciplineId")]
        public virtual List<Schedule> Schedules { get; set; }

        [ForeignKey("DisciplineId")]
        public virtual List<Curriculum> Curriculums { get; set; }

        [ForeignKey("DisciplineId")]
        public virtual List<LoadTeacher> LoadTeachers { get; set; }
    }
}
