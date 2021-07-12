using ScheduleModels;
using System;

namespace ScheduleBusinessLogic.SearchModels
{
	public class StudyGroupSearchModel : BaseSearchModel
    {
        public string Title { get; set; }

        public Guid? SpecialtyId { get; set; }

        public Guid? FacultyId { get; set; }

        public TypeEducation? TypeEducation { get; set; }

        public FormEducation? FormEducation { get; set; }

        public int? Course { get; set; }

        public int? GroupNumber { get; set; }

        public int? NumderStudents { get; set; }
    }
}