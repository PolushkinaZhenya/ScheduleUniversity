using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class TypeOfClassViewModel : AdditionalReferenceViewModel
    {
        [Column(title: "Тип занятия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }

        [Column(title: "Сокращенное название", width: 100)]
        public string AbbreviatedTitle { get; set; }
    }
}