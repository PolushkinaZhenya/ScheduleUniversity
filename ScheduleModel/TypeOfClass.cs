using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //тип занятия

    public class TypeOfClass
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AbbreviatedTitle { get; set; }

        [ForeignKey("TypeOfClassId")]
        public virtual List<Schedule> Schedules { get; set; }
    }
}
