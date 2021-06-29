using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.ViewModels
{
    public class AcademicYearViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Учебный год")]
        public string Title { get; set; }
    }
}
