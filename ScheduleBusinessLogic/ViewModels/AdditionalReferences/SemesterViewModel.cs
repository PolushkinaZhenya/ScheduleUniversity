using ScheduleBusinessLogic.Attributes;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class SemesterViewModel : AdditionalReferenceViewModel
    {
        [Column(title: "Семестр", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }

        public Guid AcademicYearId { get; set; }

        [Column(title: "Учебный год", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string AcademicYearTitle { get; set; }
    }
}