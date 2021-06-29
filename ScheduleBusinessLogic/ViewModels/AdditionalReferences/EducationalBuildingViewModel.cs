using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class EducationalBuildingViewModel : AdditionalReferenceViewModel
    {
        [Column(title: "Номер учебного корпуса", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Number { get; set; }
    }
}