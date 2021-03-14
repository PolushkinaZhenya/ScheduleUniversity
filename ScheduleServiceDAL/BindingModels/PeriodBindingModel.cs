using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.BindingModels
{
    public class PeriodBindingModel
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public Guid SemesterId { get; set; }
    }
}
