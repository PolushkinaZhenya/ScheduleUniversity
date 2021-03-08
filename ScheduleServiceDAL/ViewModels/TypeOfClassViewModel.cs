using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleServiceDAL.ViewModels
{
    public class TypeOfClassViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Тип занятия")]
        public string Title { get; set; }

        [DisplayName("Сокращенное название")]
        public string AbbreviatedTitle { get; set; }
    }
}
