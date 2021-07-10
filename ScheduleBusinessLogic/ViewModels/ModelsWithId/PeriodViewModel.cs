using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class PeriodViewModel : BaseViewModel
    {
        [Column(title: "Период", gridViewAutoSize: GridViewAutoSize.Fill, readOnly: false)]
        public string Title { get; set; }

        [Column(title: "Начало", gridViewAutoSize: GridViewAutoSize.Fill, readOnly: false, format: "dd.MM.yyyy")]
        public DateTime StartDate { get; set; }

        [Column(title: "Конец", gridViewAutoSize: GridViewAutoSize.Fill, readOnly: false, format: "dd.MM.yyyy")]
        public DateTime EndDate { get; set; }

        [Column(title: "SemesterId", visible: false)]
        public Guid SemesterId { get; set; }

        [Column(title: "Семестр", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SemesterTitle { get; set; }
    }
}