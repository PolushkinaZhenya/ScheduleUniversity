using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class SemesterBindingModel : BaseBindingModel
    {
        public string Title { get; set; }

        public Guid AcademicYearId { get; set; }
    }
}