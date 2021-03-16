using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleModel
{
    //связь расчасовка - период

    public class LoadTeacherPeriod
    {
        public Guid Id { get; set; }

        public Guid LoadTeacherId { get; set; }

        public Guid PeriodId { get; set; }

        [Required]
        public int NumderOfHours { get; set; }

        public virtual LoadTeacher LoadTeacher { get; set; }

        public virtual Period Period { get; set; }
    }
}
