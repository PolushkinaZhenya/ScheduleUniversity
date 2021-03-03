using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.BindingModels
{
    public class TeacherDepartmentBindingModel
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public int DepartmentId { get; set; }
    }
}
