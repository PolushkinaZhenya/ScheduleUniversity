using ScheduleServiceDAL.Attributes;
using System;

namespace ScheduleServiceDAL.ViewModels
{
	public class AdditionalReferenceViewModel
	{
		[Column(title: "id", visible: false)]
		public Guid Id { get; set; }
	}
}