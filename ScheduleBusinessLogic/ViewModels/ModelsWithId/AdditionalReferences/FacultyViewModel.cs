using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class FacultyViewModel : BaseViewModel
    {
        [Column(title: "Факультет", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }
    }
}