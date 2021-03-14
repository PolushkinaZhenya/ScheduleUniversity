using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleModel
{
    //учебный год

    public class AcademicYear
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("AcademicYearId")]
        public virtual List<Semester> Semesters { get; set; }
    }
}
