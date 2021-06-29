using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleBusinessLogic.ViewModels
{
    public class EducationalBuildingViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Номер учебного корпуса")]
        public string Number { get; set; }
    }
}
