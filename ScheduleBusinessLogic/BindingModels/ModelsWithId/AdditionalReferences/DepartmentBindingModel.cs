using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class DepartmentBindingModel : BaseBindingModel
    {
        public string Title { get; set; }

        public Guid TypeOfDepartmentId { get; set; }
    }
}