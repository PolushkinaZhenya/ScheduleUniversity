using ScheduleBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.BindingModels
{
	public class HtmlGenericBindingModel<T>
	{
		public string SelectedPath { get; set; }
		public List<T> Data { get; set; }

		public List<ScheduleViewModel> Lessons { get; set; }

		public List<ClassTimeViewModel> Classtimes { get; set; }
	}
}