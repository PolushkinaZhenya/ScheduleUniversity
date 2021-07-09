using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class BaseViewModel
	{
		[Column(title: "Id", visible: false)]
		public Guid Id { get; set; }
	}
}