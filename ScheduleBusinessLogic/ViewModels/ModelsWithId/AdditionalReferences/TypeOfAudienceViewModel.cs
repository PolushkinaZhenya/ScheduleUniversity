using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class TypeOfAudienceViewModel : BaseViewModel
	{
		[Column(title: "Тип аудитории", gridViewAutoSize: GridViewAutoSize.Fill)]
		public string Title { get; set; }
	}
}