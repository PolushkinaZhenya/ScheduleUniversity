using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class ClassTimeViewModel : AdditionalReferenceViewModel
    {
        [Column(title: "Номер пары", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int Number { get; set; }

        [Column(title: "Время начала", gridViewAutoSize: GridViewAutoSize.Fill)]
        public TimeSpan StartTime { get; set; }

        [Column(title: "Время окончания", gridViewAutoSize: GridViewAutoSize.Fill)]
        public TimeSpan EndTime { get; set; }
    }
}