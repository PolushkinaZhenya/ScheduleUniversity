using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class DepartmentViewModel : AdditionalReferenceViewModel
    {
        [Column(title: "Название кафедры", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }

        public Guid TypeOfDepartmentId { get; set; }

        [Column(title: "Тип кафедры", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TypeOfDepartment { get; set; }
    }
}