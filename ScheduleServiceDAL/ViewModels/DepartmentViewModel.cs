using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleServiceDAL.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название кафедры")]
        public string Title { get; set; }

        public int TypeOfDepartmentId { get; set; }

        [DisplayName("Тип кафедры")]
        public string TypeOfDepartment { get; set; }
    }
}
