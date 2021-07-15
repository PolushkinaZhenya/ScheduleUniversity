﻿using ScheduleBusinessLogic.Attributes;

namespace ScheduleBusinessLogic.ViewModels
{
	public class TypeOfClassViewModel : BaseViewModel
    {
        [Column(title: "Тип занятия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }

        [Column(title: "Сокращенное название", width: 100)]
        public string AbbreviatedTitle { get; set; }

        [Column(title: "Приоритет", width: 100)]
        public int Priority { get; set; }
    }
}