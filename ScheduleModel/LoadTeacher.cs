using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleModel
{
    //расчасовка

    public class LoadTeacher
    {
        public Guid Id { get; set; }

        public Guid DisciplineId { get; set; }

        public Guid TypeOfClassId { get; set; }

        public Guid TeacherId { get; set; }

        public Guid FlowId { get; set; }

        public virtual Discipline Discipline { get; set; }

        public virtual TypeOfClass TypeOfClass { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Flow Flow { get; set; }

        [ForeignKey("LoadTeacherId")]
        public virtual List<LoadTeacherAuditorium> LoadTeacherAuditoriums { get; set; }

        [ForeignKey("LoadTeacherId")]
        public virtual List<LoadTeacherPeriod> LoadTeacherPeriods { get; set; }
    }
}
