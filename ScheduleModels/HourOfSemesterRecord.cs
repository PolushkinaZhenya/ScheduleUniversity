using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	public class HourOfSemesterRecord : BaseEntity
	{
		[Required]
		public Guid HourOfSemesterId { get; set; }

		public virtual HourOfSemester HourOfSemester { get; set; }

		[Required]
		public Guid TypeOfClassId { get; set; }

		public virtual TypeOfClass TypeOfClass { get; set; }

		[Required]
		public Guid TeacherId { get; set; }

		public virtual Teacher Teacher { get; set; }

		[Required]
		public int TotalHours { get; set; }

		public int? SubgroupNumber { get; set; }

		public Guid? FlowId { get; set; }

		public virtual Flow Flow { get; set; }

		[ForeignKey("HourOfSemesterRecordId")]
		public virtual List<HourOfSemesterAuditorium> HourOfSemesterAuditoriums { get; set; }

		[ForeignKey("HourOfSemesterRecordId")]
		public virtual List<HourOfSemesterPeriod> HourOfSemesterPeriods { get; set; }
	}
}