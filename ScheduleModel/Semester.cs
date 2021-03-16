using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleModel
{
    //семестер

    public class Semester
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public Guid AcademicYearId { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }

        [ForeignKey("SemesterId")]
        public virtual List<Period> Periods { get; set; }

        [ForeignKey("SemesterId")]
        public virtual List<Curriculum> Curriculums { get; set; }
    }
}
