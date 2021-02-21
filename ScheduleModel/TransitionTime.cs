﻿using System;
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
        public int Id { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        public int EducationalBuildingId { get; set; }

        public virtual EducationalBuilding EducationalBuilding { get; set; }
    }
}
