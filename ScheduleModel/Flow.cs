using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleModel
{
    //поток

    public class Flow
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("FlowId")]
        public virtual List<FlowStudyGroup> FlowStudyGroups { get; set; }

        [ForeignKey("FlowId")]
        public virtual List<LoadTeacher> LoadTeachers { get; set; }
    }
}
