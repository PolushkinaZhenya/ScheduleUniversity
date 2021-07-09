using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class EducationalBuildingViewModel : BaseViewModel
    {
        [Column(title: "Название", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }

        [Column(title: "Номер учебного корпуса", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Number { get; set; }
    }
}