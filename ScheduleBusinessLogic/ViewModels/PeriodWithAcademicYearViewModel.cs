using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class PeriodWithAcademicYearViewModel : BaseViewModel
	{
		[Column(title: "Учебный год", gridViewAutoSize: GridViewAutoSize.Fill)]
		public string AcademicYearTitle { get; set; }

		[Column(title: "Семестр", gridViewAutoSize: GridViewAutoSize.Fill)]
		public string SemesterTitle { get; set; }

		[Column(title: "Период", gridViewAutoSize: GridViewAutoSize.Fill, readOnly: false)]
		public string PeriodTitle { get; set; }
	}
}