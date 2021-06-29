using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class TransitionTimeViewModel : AdditionalReferenceViewModel
    {
        [Column(title: "Время перехода", gridViewAutoSize: GridViewAutoSize.Fill)]
        public TimeSpan Time { get; set; }
        
        public Guid EducationalBuildingIdFrom { get; set; }

        [Column(title: "Из корпуса", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string EducationalBuildingFrom { get; set; }

        public Guid EducationalBuildingIdTo { get; set; }

        [Column(title: "В корпус", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string EducationalBuildingTo { get; set; }
    }
}