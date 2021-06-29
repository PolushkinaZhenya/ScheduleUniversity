using System.ComponentModel;

namespace ScheduleBusinessLogic.ViewModels
{
	public class TypeOfAudienceViewModel : AdditionalReferenceViewModel
    {
        [DisplayName("Тип аудитории")]
        public string Title { get; set; }
    }
}