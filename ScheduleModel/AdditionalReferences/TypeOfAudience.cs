using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //тип аудитории

    public class TypeOfAudience
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("TypeOfAudienceId")]
        public virtual List<Auditorium> Auditoriums { get; set; }
    }
}
