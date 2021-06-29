using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.ViewModels
{
    public class PeriodViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Период")]
        public string Title { get; set; }

        [DisplayName("Начало")]
        public DateTime StartDate { get; set; }

        [DisplayName("Конец")]
        public DateTime EndDate { get; set; }

        public Guid SemesterId { get; set; }
        [DisplayName("Семестр")]
        public string SemesterTitle { get; set; }
    }
}
