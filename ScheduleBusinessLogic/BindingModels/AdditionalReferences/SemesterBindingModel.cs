using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class SemesterBindingModel : AdditionalReferenceBindingModel
    {
        public string Title { get; set; }

        public Guid AcademicYearId { get; set; }
    }
}