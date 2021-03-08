using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleServiceDAL.ViewModels
{
    public class TransitionTimeViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Время перехода")]
        public TimeSpan Time { get; set; }
        
        public Guid EducationalBuildingId_1 { get; set; }
        [DisplayName("Из корпуса")]
        public string EducationalBuildingFrom { get; set; }

        public Guid EducationalBuildingId_2 { get; set; }
        [DisplayName("В корпус")]
        public string EducationalBuildingTo { get; set; }
    }
}
