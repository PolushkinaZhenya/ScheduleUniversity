using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleModel
{
    //связь поток - группа

    public class FlowStudyGroup
    {
        public Guid Id { get; set; }

        public Guid FlowId { get; set; }

        public Guid StudyGroupId { get; set; }

        public int Subgroup { get; set; }

        public virtual Flow Flow { get; set; }

        public virtual StudyGroup StudyGroup { get; set; }
    }
}
