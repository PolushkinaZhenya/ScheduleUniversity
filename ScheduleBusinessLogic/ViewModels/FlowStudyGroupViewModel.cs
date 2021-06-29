using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.ViewModels
{
    public class FlowStudyGroupViewModel
    {
        public Guid Id { get; set; }

        public Guid FlowId { get; set; }

        public Guid StudyGroupId { get; set; }
        [DisplayName("Группа")]
        public string StudyGroupTitle { get; set; }

        [DisplayName("Подгруппа")]
        public int? Subgroup { get; set; }
    }
}
