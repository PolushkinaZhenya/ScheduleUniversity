using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //время пар

    public class ClassTime
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [ForeignKey("ClassTimeId")]
        public virtual List<Schedule> Schedules { get; set; }
    }
}
