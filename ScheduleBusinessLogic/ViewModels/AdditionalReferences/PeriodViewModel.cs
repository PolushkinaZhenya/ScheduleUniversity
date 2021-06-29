using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class PeriodViewModel : AdditionalReferenceViewModel
    {
        [Column(title: "Период", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }

        [Column(title: "Начало", gridViewAutoSize: GridViewAutoSize.Fill)]
        public DateTime StartDate { get; set; }

        [Column(title: "Конец", gridViewAutoSize: GridViewAutoSize.Fill)]
        public DateTime EndDate { get; set; }

        public Guid SemesterId { get; set; }

        [Column(title: "Семестр", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SemesterTitle { get; set; }
    }
}