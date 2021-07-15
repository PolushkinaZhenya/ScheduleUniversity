using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class HourOfSemesterPeriodViewModel : BaseViewModel
    {
        public Guid HourOfSemesterRecordId { get; set; }

        public Guid PeriodId { get; set; }

        [Column(title: "Период", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string PeriodTitle { get; set; }

        [Column(title: "Часов в первую неделю", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int HoursFirstWeek { get; set; }

        [Column(title: "Часов во вторую неделю", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int HoursSecondWeek { get; set; }
    }
}