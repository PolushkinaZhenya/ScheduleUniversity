using ScheduleModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.ViewModels
{
    public class ScheduleViewModel
    {
        public Guid Id { get; set; }

        public Guid PeriodId { get; set; }
        [DisplayName("Период")]
        public string PeriodTitle { get; set; }

        [DisplayName("Номер недели")]
        public int NumberWeeks { get; set; }

        [DisplayName("День недели")]
        public DayOfTheWeek? DayOfTheWeek { get; set; }

        public Guid? ClassTimeId { get; set; }
        [DisplayName("Номер пары")]
        public int? ClassTimeNumber { get; set; }

        [DisplayName("Тип записи")]
        public string Type { get; set; }

        public Guid StudyGroupId { get; set; }
        [DisplayName("Группа")]
        public string StudyGroupTitle { get; set; }

        [DisplayName("Подгруппа")]
        public int? Subgroups { get; set; }
        
        public Guid? AuditoriumId { get; set; }
        [DisplayName("Аудитория")]
        public string AuditoriumNumber { get; set; }

        //public Guid TypeOfClassId { get; set; }
        [DisplayName("Тип занятия")]
        public string TypeOfClassTitle { get; set; }

        //public Guid DisciplineId { get; set; }
        [DisplayName("Дисциплина")]
        public string DisciplineTitle { get; set; }

        public Guid TeacherId { get; set; }
        [DisplayName("Преподаватель")]
        public string TeacherSurname { get; set; }

        [DisplayName("Расчасовка")]
        public Guid LoadTeacherId { get; set; }
    }
}
