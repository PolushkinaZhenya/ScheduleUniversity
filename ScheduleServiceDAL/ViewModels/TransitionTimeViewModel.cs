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
        public int Id { get; set; }

        [DisplayName("Время перехода")]
        public TimeSpan Time { get; set; }

        
        public int EducationalBuildingId { get; set; }
        [DisplayName("Из корпуса")]
        public string EducationalBuildingFrom { get; set; }
    }
}
