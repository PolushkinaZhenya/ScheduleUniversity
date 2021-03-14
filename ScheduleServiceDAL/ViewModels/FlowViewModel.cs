﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.ViewModels
{
    public class FlowViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Название")]
        public string Title { get; set; }
        
        public List<FlowStudyGroupViewModel> FlowStudyGroups { get; set; }
    }
}
