using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class AcademicYearViewModel : BaseViewModel
    {
        [Column(title: "Учебный год", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }
    }
}