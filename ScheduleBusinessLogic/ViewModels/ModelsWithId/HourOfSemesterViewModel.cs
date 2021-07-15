using ScheduleBusinessLogic.Attributes;
using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.ViewModels
{
	public class HourOfSemesterViewModel : BaseViewModel
    {
        public Guid SemesterId { get; set; }

        [Column(title: "Семестр", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SemesterTitle { get; set; }

        public Guid DisciplineId { get; set; }

        [Column(title: "Дисциплина", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DisciplineTitle { get; set; }

        public Guid StudyGroupId { get; set; }

        [Column(title: "Группа", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string StudyGroupTitle { get; set; }

        [Column(title: "Отчетность", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Reporting { get; set; }

        [Column(title: "Пожелания", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Wishes { get; set; }

        public List<HourOfSemesterRecordViewModel> HourOfSemesterRecords { get; set; }
    }
}