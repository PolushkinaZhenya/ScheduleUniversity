using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.ViewModels
{
    public class TypeOfAudienceViewModel
    {
        public int Id { get; set; }

        [DisplayName("Тип аудитории")]
        public string Title { get; set; }
    }
}
