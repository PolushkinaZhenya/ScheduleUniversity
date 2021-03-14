using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.BindingModels
{
    public class FlowBindingModel
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public List<FlowStudyGroupBindingModel> FlowStudyGroups { get; set; }
    }
}
