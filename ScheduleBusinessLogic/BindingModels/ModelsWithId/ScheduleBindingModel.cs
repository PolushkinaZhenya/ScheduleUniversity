using ScheduleModels;
using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class ScheduleBindingModel : BaseBindingModel
    {
        public Guid HourOfSemesterPeriodId { get; set; }

        public string Type { get; set; } //тип записи (занятие, аудитория, преподаватель)

        public int NumberWeeks { get; set; } //номер недели

        public DayOfTheWeek? DayOfTheWeek { get; set; } //день недели

        public Guid? ClassTimeId { get; set; }

        public Guid? AuditoriumId { get; set; }
    }
}
