using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.BindingModels
{
    public class AuditoriumBindingModel
    {
        public int Id { get; set; }
        
        public string Number { get; set; }
        
        public int Capacity { get; set; }

        public int EducationalBuildingId { get; set; }

        public int TypeOfAudienceId { get; set; }

        public int DepartmentId { get; set; }
    }
}
