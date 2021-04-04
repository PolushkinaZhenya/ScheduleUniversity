using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.ViewModels
{
    public class LoadTeacherViewModel
    {
        public Guid Id { get; set; }

        public Guid DisciplineId { get; set; }
        [DisplayName("Дисциплина")]
        public string DisciplineTitle { get; set; }

        public Guid TypeOfClassId { get; set; }
        [DisplayName("Тип занятия")]
        public string TypeOfClassTitle { get; set; }

        public Guid TeacherId { get; set; }
        [DisplayName("Преподаватель")]
        public string TeacherSurname { get; set; }

        public Guid FlowId { get; set; }
        [DisplayName("Поток")]
        public string FlowTitle { get; set; }

        [DisplayName("Часы")]
        public int NumderOfHours { get; set; }

        public List<LoadTeacherPeriodViewModel> LoadTeacherPeriods { get; set; }

        public List<LoadTeacherAuditoriumViewModel> LoadTeacherAuditoriums { get; set; }
    }
}
