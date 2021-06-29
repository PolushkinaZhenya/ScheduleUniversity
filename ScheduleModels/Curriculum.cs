﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleModel
{
    //учебный план

    public class Curriculum
    {
        public Guid Id { get; set; }

        public Guid DisciplineId { get; set; }

        public Guid StudyGroupId { get; set; }

        public Guid TypeOfClassId { get; set; }

        public Guid SemesterId { get; set; }

        [Required]
        public int NumderOfHours { get; set; }

        public virtual Discipline Discipline { get; set; }

        public virtual StudyGroup StudyGroup { get; set; }

        public virtual TypeOfClass TypeOfClass { get; set; }

        public virtual Semester Semester { get; set; }
    }
}
