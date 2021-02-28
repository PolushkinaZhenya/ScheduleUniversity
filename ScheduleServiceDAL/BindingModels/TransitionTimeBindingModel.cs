using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.BindingModels
{
    public class TransitionTimeBindingModel
    {
        public int Id { get; set; }
        
        public TimeSpan Time { get; set; }

        public int EducationalBuildingId { get; set; }
    }
}
