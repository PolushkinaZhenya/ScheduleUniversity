using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.BindingModels
{
    public class CurriculumBindingModel
    {
        public Guid Id { get; set; }

        public Guid DisciplineId { get; set; }

        public Guid StudyGroupId { get; set; }

        public Guid TypeOfClassId { get; set; }

        public Guid SemesterId { get; set; }
        
        public int NumderOfHours { get; set; }
    }
}
