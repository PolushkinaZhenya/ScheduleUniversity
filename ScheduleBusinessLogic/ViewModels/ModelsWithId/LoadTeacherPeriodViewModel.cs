using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class LoadTeacherPeriodViewModel : BaseViewModel
    {
        public Guid LoadTeacherId { get; set; }

        public Guid PeriodId { get; set; }

        [Column(title: "Период", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string PeriodTitle { get; set; }

        [Column(title: "Всего часов", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int TotalHours { get; set; }

        [Column(title: "Часов в первую неделю", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int HoursFirstWeek { get; set; }

        [Column(title: "Часов во вторую неделю", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int HoursSecondWeek { get; set; }
    }
}