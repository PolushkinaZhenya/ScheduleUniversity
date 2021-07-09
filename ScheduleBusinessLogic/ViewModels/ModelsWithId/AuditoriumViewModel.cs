using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class AuditoriumViewModel : BaseViewModel
    {
        [Column(title: "Номер аудитории", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Number { get; set; }

        [Column(title: "Вместимость", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int Capacity { get; set; }

        public Guid TypeOfAudienceId { get; set; }

        [Column(title: "Тип аудитории", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TypeOfAudience { get; set; }

        public Guid EducationalBuildingId { get; set; }

        [Column(title: "Корпус", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string EducationalBuilding { get; set; }
        
        public Guid DepartmentId { get; set; }

        [Column(title: "Кафедра", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Department { get; set; }
    }
}