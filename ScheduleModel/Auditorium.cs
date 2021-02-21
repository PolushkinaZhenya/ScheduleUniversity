using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //аудитория

    public class Auditorium
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public int Capacity { get; set; }

        public int EducationalBuildingId { get; set; }

        public int TypeOfAudienceId { get; set; }

        public virtual EducationalBuilding EducationalBuilding { get; set; }

        public virtual TypeOfAudience TypeOfAudience { get; set; }
    }
}
