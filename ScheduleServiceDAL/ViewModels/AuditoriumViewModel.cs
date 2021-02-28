using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleServiceDAL.ViewModels
{
    public class AuditoriumViewModel
    {
        public int Id { get; set; }

        [DisplayName("Номер аудитории")]
        public string Number { get; set; }

        [DisplayName("Вместимость")]
        public int Capacity { get; set; }

        public int TypeOfAudienceId { get; set; }
        [DisplayName("Тип аудитории")]
        public string TypeOfAudience { get; set; }

        public int EducationalBuildingId { get; set; }
        [DisplayName("Корпус")]
        public string EducationalBuilding { get; set; }
        
        public int DepartmentId { get; set; }
        [DisplayName("Кафедра")]
        public string Department { get; set; }
    }
}
