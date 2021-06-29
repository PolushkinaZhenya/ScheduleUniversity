using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.BindingModels
{
    public class TransitionTimeBindingModel
    {
        public Guid Id { get; set; }
        
        public TimeSpan Time { get; set; }

        public Guid EducationalBuildingId_1 { get; set; }

        public Guid EducationalBuildingId_2 { get; set; }
    }
}
