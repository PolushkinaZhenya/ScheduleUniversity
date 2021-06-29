using System.ComponentModel;

namespace ScheduleBusinessLogic.ViewModels
{
	public class TypeOfDepartmentViewModel : AdditionalReferenceViewModel
    {
        [DisplayName("Тип кафедры")]
        public string Title { get; set; }
    }
}