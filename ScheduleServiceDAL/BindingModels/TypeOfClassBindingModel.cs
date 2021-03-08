using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.BindingModels
{
    public class TypeOfClassBindingModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public string AbbreviatedTitle { get; set; }
    }
}
