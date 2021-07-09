using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class SpecialtyViewModel : BaseViewModel
    {
        [Column(title: "Код специальности", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Code { get; set; }

        [Column(title: "Название", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }

        [Column(title: "Сокращенное название", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string AbbreviatedTitle { get; set; }

        public Guid FacultyId { get; set; }

        [Column(title: "Факультет", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FacultyTitle { get; set; }
    }
}