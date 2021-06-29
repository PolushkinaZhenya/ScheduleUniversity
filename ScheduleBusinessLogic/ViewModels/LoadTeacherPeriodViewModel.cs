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

        [DisplayName("Всего часов")]
        public int TotalHours { get; set; }

        [DisplayName("Часов в первую неделю")]
        public int HoursFirstWeek { get; set; }

        [DisplayName("Часов во вторую неделю")]
        public int HoursSecondWeek { get; set; }
    }
}
