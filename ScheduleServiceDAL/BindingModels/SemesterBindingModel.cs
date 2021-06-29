using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.BindingModels
{
    public class SemesterBindingModel
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public Guid AcademicYearId { get; set; }
    }
}
