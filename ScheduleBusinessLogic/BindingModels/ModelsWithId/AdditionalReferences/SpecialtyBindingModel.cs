using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class SpecialtyBindingModel : BaseBindingModel
    {
        public string Code { get; set; }
        
        public string Title { get; set; }
        
        public string AbbreviatedTitle { get; set; }

        public Guid FacultyId { get; set; }
    }
}