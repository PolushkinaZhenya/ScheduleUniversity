using ScheduleModels;
using System;

namespace ScheduleBusinessLogic.BindingModels
{
	public class StudyGroupBindingModel : BaseBindingModel
    {
        public string Title { get; set; }

        public Guid SpecialtyId { get; set; }

        public TypeEducation TypeEducation { get; set; }

        public FormEducation FormEducation { get; set; }
        
        public int Course { get; set; }

        public int GroupNumber { get; set; }

        public int NumderStudents { get; set; }
        
        public int NumderSubgroups { get; set; }
    }
}