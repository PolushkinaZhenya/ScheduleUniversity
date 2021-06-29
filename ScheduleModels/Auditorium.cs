using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ScheduleModels;

namespace ScheduleModel
{
    //аудитория

    public class Auditorium
    {
        public Guid Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public int Capacity { get; set; }

        public Guid EducationalBuildingId { get; set; }

        public Guid TypeOfAudienceId { get; set; }

        public Guid DepartmentId { get; set; }

        public virtual EducationalBuilding EducationalBuilding { get; set; }

        public virtual TypeOfAudience TypeOfAudience { get; set; }

        public virtual Department Department { get; set; }

        [ForeignKey("AuditoriumId")]
        public virtual List<Schedule> Schedules { get; set; }

        [ForeignKey("AuditoriumId")]
        public virtual List<LoadTeacherAuditorium> LoadTeacherAuditoriums { get; set; }
    }
}
