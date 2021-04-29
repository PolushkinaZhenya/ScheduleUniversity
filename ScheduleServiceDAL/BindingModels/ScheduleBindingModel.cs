using ScheduleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.BindingModels
{
    public class ScheduleBindingModel
    {
        public Guid Id { get; set; }

        public DayOfTheWeek? DayOfTheWeek { get; set; }

        public int? Subgroups { get; set; }
        
        public int NumberWeeks { get; set; } 

        public Guid? AuditoriumId { get; set; }

        public Guid? ClassTimeId { get; set; }

        //public Guid TeacherId { get; set; }

        //public Guid TypeOfClassId { get; set; }

        //public Guid DisciplineId { get; set; }

        public Guid StudyGroupId { get; set; }

        public Guid PeriodId { get; set; }

        public Guid LoadTeacherId { get; set; }
    }
}
