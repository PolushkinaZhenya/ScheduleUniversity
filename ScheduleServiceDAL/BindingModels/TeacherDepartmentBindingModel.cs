using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.BindingModels
{
    public class TeacherDepartmentBindingModel
    {
        public Guid Id { get; set; }

        public Guid TeacherId { get; set; }

        public Guid DepartmentId { get; set; }
    }
}
