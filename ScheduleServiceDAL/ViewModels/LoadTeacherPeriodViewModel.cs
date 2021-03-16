using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.ViewModels
{
    public class LoadTeacherPeriodViewModel
    {
        public Guid Id { get; set; }

        public Guid LoadTeacherId { get; set; }

        public Guid PeriodId { get; set; }
        [DisplayName("Период")]
        public string PeriodTitle { get; set; }

        [DisplayName("Часы")]
        public int NumderOfHours { get; set; }
    }
}
