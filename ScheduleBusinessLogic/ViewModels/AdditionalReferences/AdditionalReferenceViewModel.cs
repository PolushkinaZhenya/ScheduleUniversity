using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class AdditionalReferenceViewModel
	{
		[Column(title: "id", visible: false)]
		public Guid Id { get; set; }
	}
}