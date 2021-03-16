using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.ViewModels
{
    public class LoadTeacherAuditoriumViewModel
    {
        public Guid Id { get; set; }

        public Guid LoadTeacherId { get; set; }
        
        public Guid AuditoriumId { get; set; }
        [DisplayName("Аудитория")]
        public string AuditoriumTitle { get; set; }
    }
}
