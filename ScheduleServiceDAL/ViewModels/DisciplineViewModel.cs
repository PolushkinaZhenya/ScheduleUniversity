using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleServiceDAL.ViewModels
{
    public class DisciplineViewModel
    {
        public int Id { get; set; }

        [DisplayName("Дисциплина")]
        public string Title { get; set; }

        [DisplayName("Сокращенное название")]
        public string AbbreviatedTitle { get; set; }
    }
}
