using System.ComponentModel;

namespace ScheduleServiceDAL.ViewModels
{
	public class TypeOfAudienceViewModel : AdditionalReferenceViewModel
    {
        [DisplayName("Тип аудитории")]
        public string Title { get; set; }
    }
}