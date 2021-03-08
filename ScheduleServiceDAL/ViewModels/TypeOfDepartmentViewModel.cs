using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.ViewModels
{
    public class TypeOfDepartmentViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Тип кафедры")]
        public string Title { get; set; }
    }
}
