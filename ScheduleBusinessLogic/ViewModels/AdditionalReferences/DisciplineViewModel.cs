﻿using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class DisciplineViewModel : AdditionalReferenceViewModel
    {
        [Column(title: "Дисциплина", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }

        [Column(title: "Сокращенное название", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string AbbreviatedTitle { get; set; }
    }
}