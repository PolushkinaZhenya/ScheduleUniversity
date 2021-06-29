using System.ComponentModel;

namespace ScheduleBusinessLogic.ViewModels
{
	public class TypeOfClassViewModel : AdditionalReferenceViewModel
    {
        [DisplayName("Тип занятия")]
        public string Title { get; set; }

        [DisplayName("Сокращенное название")]
        public string AbbreviatedTitle { get; set; }
    }
}