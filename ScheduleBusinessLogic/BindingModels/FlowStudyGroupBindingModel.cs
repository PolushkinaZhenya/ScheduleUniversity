using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.BindingModels
{
    public class FlowStudyGroupBindingModel
    {
        public Guid Id { get; set; }

        public Guid FlowId { get; set; }

        public Guid StudyGroupId { get; set; }

        public int? Subgroup { get; set; }
    }
}
