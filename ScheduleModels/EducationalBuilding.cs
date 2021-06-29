using System;
using System.Collections.Generic;
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

        [ForeignKey("EducationalBuildingIdFrom")]
        public virtual List<TransitionTime> TransitionTimesFrom { get; set; }

        [ForeignKey("EducationalBuildingIdTo")]
        public virtual List<TransitionTime> TransitionTimesTo { get; set; }

    }
}