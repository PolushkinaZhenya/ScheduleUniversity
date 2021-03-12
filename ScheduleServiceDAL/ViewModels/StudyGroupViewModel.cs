using ScheduleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleServiceDAL.ViewModels
{
    public class StudyGroupViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Название")]
        public string Title { get; set; }

        [DisplayName("Курс")]
        public int Course { get; set; }

        [DisplayName("Кол-во студентов")]
        public int NumderStudents { get; set; }

        [DisplayName("Кол-во подгрупп")]
        public int NumderSubgroups { get; set; }

        public Guid SpecialtyId { get; set; }
        [DisplayName("Специальность")]
        public string SpecialtyTitle { get; set; }

        [DisplayName("Тип обучения")]
        public TypeEducation TypeEducation { get; set; }

        [DisplayName("Форма обучения")]
        public FormEducation FormEducation { get; set; }
    }
}
