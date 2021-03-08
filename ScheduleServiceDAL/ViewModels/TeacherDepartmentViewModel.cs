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
        public Guid Id { get; set; }

        public Guid TeacherId { get; set; }

        public Guid DepartmentId { get; set; }
        [DisplayName("Кафедра")]
        public string DepartmentTitle { get; set; }
    }
}
