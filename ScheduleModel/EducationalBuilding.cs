using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //учебный корпус

    public class EducationalBuilding
    {
        public Guid Id { get; set; }

        [Required]
        public string Number { get; set; }

        [ForeignKey("EducationalBuildingId")]
        public virtual List<Auditorium> Auditoriums { get; set; }

        [ForeignKey("EducationalBuildingId_1")]
        public virtual List<TransitionTime> TransitionTimes_1 { get; set; }

        [ForeignKey("EducationalBuildingId_2")]
        public virtual List<TransitionTime> TransitionTimes_2 { get; set; }

    }
}
