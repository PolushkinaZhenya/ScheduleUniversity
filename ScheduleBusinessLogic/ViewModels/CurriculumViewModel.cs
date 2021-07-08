using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class CurriculumViewModel
    {
        [Column(title: "id", visible: false)]
        public Guid Id { get; set; }

        public Guid DisciplineId { get; set; }

        [Column(title: "Дисциплина", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DisciplineTitle { get; set; }

        public Guid StudyGroupId { get; set; }

        [Column(title: "Группа", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string StudyGroupTitle { get; set; }

        public Guid TypeOfClassId { get; set; }

        [Column(title: "Тип занятия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TypeOfClassTitle { get; set; }

        public Guid SemesterId { get; set; }

        [Column(title: "Семестр", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SemesterTitle { get; set; }

        [Column(title: "Кол-во часов", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int NumderOfHours { get; set; }
    }
}