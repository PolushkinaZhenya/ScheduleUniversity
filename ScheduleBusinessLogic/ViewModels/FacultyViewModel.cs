using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleServiceDAL.ViewModels
{
    public class FacultyViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Факультет")]
        public string Title { get; set; }
    }
}
