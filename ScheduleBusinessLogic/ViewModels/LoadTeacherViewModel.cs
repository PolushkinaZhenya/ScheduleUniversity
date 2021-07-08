using ScheduleBusinessLogic.Attributes;
using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.ViewModels
{
	public class LoadTeacherViewModel
    {
        [Column(title: "id", visible: false)]
        public Guid Id { get; set; }

        public Guid DisciplineId { get; set; }

        [Column(title: "Дисциплина", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DisciplineTitle { get; set; }

        public Guid TypeOfClassId { get; set; }

        [Column(title: "Тип занятия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TypeOfClassTitle { get; set; }

        public Guid TeacherId { get; set; }

        [Column(title: "Преподаватель", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TeacherSurname { get; set; }

        public Guid FlowId { get; set; }

        [Column(title: "Поток", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FlowTitle { get; set; }

        [Column(title: "Отчетность", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Reporting { get; set; }

        [Column(title: "Кол-во подгрупп", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int? NumberOfSubgroups { get; set; }

        [Column(title: "Часов за период", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int TotalHours { get; set; }

        [Column(title: "Часов в первую неделю", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int HoursFirstWeek { get; set; }

        [Column(title: "Часов во вторую неделю", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int HoursSecondWeek { get; set; }

        public List<LoadTeacherPeriodViewModel> LoadTeacherPeriods { get; set; }

        public List<LoadTeacherAuditoriumViewModel> LoadTeacherAuditoriums { get; set; }
    }
}