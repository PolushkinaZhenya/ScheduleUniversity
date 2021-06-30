using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class DepartmentBindingModel : AdditionalReferenceBindingModel
    {
        public string Title { get; set; }

        public Guid TypeOfDepartmentId { get; set; }
    }
}