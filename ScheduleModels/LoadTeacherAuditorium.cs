using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleModel
{
    //связь расчасовка - аудитория

    public class LoadTeacherAuditorium
    {
        public Guid Id { get; set; }

        public Guid LoadTeacherId { get; set; }

        public Guid AuditoriumId { get; set; }

        public int Priority { get; set; }

        public virtual LoadTeacher LoadTeacher { get; set; }

        public virtual Auditorium Auditorium { get; set; }

    }
}
