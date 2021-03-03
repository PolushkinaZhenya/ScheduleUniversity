using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleServiceDAL.ViewModels
{
    public class TeacherDepartmentViewModel
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public int DepartmentId { get; set; }
        [DisplayName("Кафедра")]
        public string DepartmentTitle { get; set; }
    }
}
