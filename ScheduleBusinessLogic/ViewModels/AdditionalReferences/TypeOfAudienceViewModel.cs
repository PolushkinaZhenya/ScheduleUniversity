using ScheduleServiceDAL.Attributes;

namespace ScheduleServiceDAL.ViewModels
{
	public class TypeOfAudienceViewModel : AdditionalReferenceViewModel
	{
		[Column(title: "Тип аудитории", gridViewAutoSize: GridViewAutoSize.Fill)]
		public string Title { get; set; }
	}
}