using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class TypeOfDepartmentViewModel : AdditionalReferenceViewModel
    {
        [Column(title: "Тип кафедры", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }
    }
}