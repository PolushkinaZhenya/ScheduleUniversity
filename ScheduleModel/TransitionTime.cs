using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //время перехода между корпусами

    public class TransitionTime
    {
        public Guid Id { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        public Guid EducationalBuildingId_1 { get; set; }

        public Guid EducationalBuildingId_2 { get; set; }

        public virtual EducationalBuilding EducationalBuilding { get; set; }
    }
}
