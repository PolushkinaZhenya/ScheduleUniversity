using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class SpecialtySearchModel : BaseSearchModel
    {
        public string Code { get; set; }

        public string Title { get; set; }

        public string AbbreviatedTitle { get; set; }

        public Guid? FacultyId { get; set; }
    }
}