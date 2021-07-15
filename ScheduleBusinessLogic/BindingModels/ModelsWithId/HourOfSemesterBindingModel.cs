using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.BindingModels
{
	public class HourOfSemesterBindingModel : BaseBindingModel
    {
        public Guid DisciplineId { get; set; }

        public Guid StudyGroupId { get; set; }

        public Guid SemesterId { get; set; }

        public string Reporting { get; set; }

        public string Wishes { get; set; }

        public List<HourOfSemesterRecordBindingModel> HourOfSemesterRecords { get; set; }
    }
}