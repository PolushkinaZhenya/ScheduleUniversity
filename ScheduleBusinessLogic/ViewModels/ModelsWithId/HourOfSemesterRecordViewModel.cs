using ScheduleBusinessLogic.Attributes;
using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.ViewModels
{
	public class HourOfSemesterRecordViewModel : BaseViewModel
	{
		public Guid HourOfSemesterId { get; set; }

		public int Order { get; set; }

		public Guid TypeOfClassId { get; set; }

		[Column(title: "Тип занятия", gridViewAutoSize: GridViewAutoSize.Fill)]
		public string TypeOfClassTitle { get; set; }

		public Guid TeacherId { get; set; }

		[Column(title: "Преподаватель", gridViewAutoSize: GridViewAutoSize.Fill)]
		public string TeacherShortName { get; set; }

		[Column(title: "Всего часов", gridViewAutoSize: GridViewAutoSize.Fill)]
		public int TotalHours { get; set; }

		[Column(title: "Подгруппа", gridViewAutoSize: GridViewAutoSize.Fill)]
		public int? SubgroupNumber { get; set; }

		public Guid? FlowId { get; set; }

		[Column(title: "Поток", gridViewAutoSize: GridViewAutoSize.Fill)]
		public string FlowTitle { get; set; }

		public List<string> Flows { get; set; }

		public List<HourOfSemesterPeriodViewModel> HourOfSemesterPeriods { get; set; }

		public List<HourOfSemesterAuditoriumViewModel> HourOfSemesterAuditoriums { get; set; }
	}
}