using ScheduleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.BindingModels
{
    public class ScheduleBindingModel : BaseBindingModel
    {
        public Guid PeriodId { get; set; } //период

        public DayOfTheWeek? DayOfTheWeek { get; set; } //день недели

        public int NumberWeeks { get; set; } //номер недели

        public string Type { get; set; } //тип записи (занятие, аудитория, преподаватель)

        public Guid? AuditoriumId { get; set; }

        public Guid? ClassTimeId { get; set; }

        public Guid? StudyGroupId { get; set; } //группа

        public int? Subgroups { get; set; } //подгруппа

        public Guid? LoadTeacherId { get; set; }

        public Guid? TeacherId { get; set; } //учитель
    }
}
