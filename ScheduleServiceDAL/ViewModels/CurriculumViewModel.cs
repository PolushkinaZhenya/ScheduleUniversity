using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.ViewModels
{
    public class CurriculumViewModel
    {
        public Guid Id { get; set; }

        public Guid DisciplineId { get; set; }
        [DisplayName("Дисциплина")]
        public string DisciplineTitle { get; set; }

        public Guid StudyGroupId { get; set; }
        [DisplayName("Группа")]
        public string StudyGroupTitle { get; set; }

        public Guid TypeOfClassId { get; set; }
        [DisplayName("Тип занятия")]
        public string TypeOfClassTitle { get; set; }

        public Guid SemesterId { get; set; }
        [DisplayName("Семестр")]
        public string SemesterTitle { get; set; }

        [DisplayName("Кол-во часов")]
        public int NumderOfHours { get; set; }
    }
}
