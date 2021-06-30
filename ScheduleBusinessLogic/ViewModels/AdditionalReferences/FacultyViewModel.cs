using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class FacultyViewModel : AdditionalReferenceViewModel
    {
        [Column(title: "Факультет", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }
    }
}