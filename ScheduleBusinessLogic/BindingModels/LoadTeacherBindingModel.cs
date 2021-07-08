using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.BindingModels
{
	public class LoadTeacherBindingModel
    {
        public Guid Id { get; set; }

        public Guid DisciplineId { get; set; }

        public Guid TypeOfClassId { get; set; }

        public Guid TeacherId { get; set; }

        public Guid FlowId { get; set; }

        public string Reporting { get; set; }

        public int? NumberOfSubgroups { get; set; }

        public List<LoadTeacherPeriodBindingModel> LoadTeacherPeriods { get; set; }

        public List<LoadTeacherAuditoriumBindingModel> LoadTeacherAuditoriums { get; set; }

        public List<ScheduleBindingModel> Schedules { get; set; }
    }
}