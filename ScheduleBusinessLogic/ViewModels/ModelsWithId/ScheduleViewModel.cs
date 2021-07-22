using ScheduleBusinessLogic.Attributes;
using ScheduleModels;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class ScheduleViewModel : BaseViewModel
    {
        public Guid HourOfSemesterPeriodId { get; set; }

        public string Type { get; set; }

        [Column(title: "Номер недели", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int NumberWeeks { get; set; }

        [Column(title: "Дисциплина", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DisciplineTitle { get; set; }

        public Guid? TeacherId { get; set; }

        [Column(title: "Преподаватель", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TeacherShortName { get; set; }

        [Column(title: "Подгруппа", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SubgroupsTitle { get { return Subgroups.HasValue ? Subgroups.Value.ToString() : string.Empty; } }

        public DayOfTheWeek? DayOfTheWeek { get; set; }

        public Guid? ClassTimeId { get; set; }

        public int? ClassTimeNumber { get; set; }

        public Guid StudyGroupId { get; set; }

        public string StudyGroupTitle { get; set; }

        public int? Subgroups { get; set; }
        
        public Guid? AuditoriumId { get; set; }

        public string AuditoriumNumber { get; set; }

        [Column(title: "Тип занятия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TypeOfClassTitle { get; set; }
    }
}
