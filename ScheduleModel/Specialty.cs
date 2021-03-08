using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //специальность

    public class Specialty
    {
        public Guid Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AbbreviatedTitle { get; set; }

        public Guid FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
