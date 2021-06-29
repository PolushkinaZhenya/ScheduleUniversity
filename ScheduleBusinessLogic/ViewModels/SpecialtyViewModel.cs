using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleBusinessLogic.ViewModels
{
    public class SpecialtyViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Код специальности")]
        public string Code { get; set; }

        [DisplayName("Название")]
        public string Title { get; set; }

        [DisplayName("Сокращенное название")]
        public string AbbreviatedTitle { get; set; }

        public Guid FacultyId { get; set; }
        [DisplayName("Факультет")]
        public string FacultyTitle { get; set; }
    }
}
