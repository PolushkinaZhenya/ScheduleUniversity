using System.ComponentModel;

namespace ScheduleServiceDAL.ViewModels
{
	public class TypeOfDepartmentViewModel : AdditionalReferenceViewModel
    {
        [DisplayName("Тип кафедры")]
        public string Title { get; set; }
    }
}