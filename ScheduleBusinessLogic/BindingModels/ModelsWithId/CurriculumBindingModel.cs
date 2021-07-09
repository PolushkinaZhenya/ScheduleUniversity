using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class CurriculumBindingModel : BaseBindingModel
    {
        public Guid DisciplineId { get; set; }

        public Guid StudyGroupId { get; set; }

        public Guid TypeOfClassId { get; set; }

        public Guid SemesterId { get; set; }
        
        public int NumderOfHours { get; set; }
    }
}