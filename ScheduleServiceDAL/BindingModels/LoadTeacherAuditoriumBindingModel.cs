using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.BindingModels
{
    public class LoadTeacherAuditoriumBindingModel
    {
        public Guid Id { get; set; }

        public Guid LoadTeacherId { get; set; }

        public Guid AuditoriumId { get; set; }
    }
}
