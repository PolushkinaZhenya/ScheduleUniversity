using ScheduleModels;
using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class ScheduleSearchModel : BaseSearchModel
    {
        public Guid? HourOfSemesterPeriodId { get; set; }

        public string Type { get; set; } //тип записи (занятие, аудитория, преподаватель)

        public int? NumberWeeks { get; set; } //номер недели

        public DayOfTheWeek? DayOfTheWeek { get; set; } //день недели

        public Guid? ClassTimeId { get; set; }

        public Guid? AuditoriumId { get; set; }

        public Guid? StudyGroupId { get; set; }

        public Guid? TeacherId { get; set; }

        public Guid? PeriodId { get; set; }

        public Guid? FlowId { get; set; }

        public bool? IsFree { get; set; }
    }
}