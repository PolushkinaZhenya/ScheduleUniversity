using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleServiceDAL.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }

        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        public List<TeacherDepartmentViewModel> TeacherDepartments { get; set; }
    }
}
