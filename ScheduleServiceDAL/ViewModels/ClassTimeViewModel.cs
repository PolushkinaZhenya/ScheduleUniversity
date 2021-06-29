using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleBusinessLogic.ViewModels
{
    public class ClassTimeViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Номер пары")]
        public int Number { get; set; }

        [DisplayName("Время начала")]
        public TimeSpan StartTime { get; set; }

        [DisplayName("Время окончания")]
        public TimeSpan EndTime { get; set; }
    }
}
