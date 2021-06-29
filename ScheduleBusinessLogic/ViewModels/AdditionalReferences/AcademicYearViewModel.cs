using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class AcademicYearViewModel : AdditionalReferenceViewModel
    {
        [Column(title: "Учебный год", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }
    }
}