using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.ViewModels
{
    public class SemesterViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Семестр")]
        public string Title { get; set; }

        public Guid AcademicYearId { get; set; }
        [DisplayName("Учебный год")]
        public string AcademicYearTitle { get; set; }
    }
}
