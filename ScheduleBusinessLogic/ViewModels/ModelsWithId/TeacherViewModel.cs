using ScheduleBusinessLogic.Attributes;
using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.ViewModels
{
	public class TeacherViewModel : BaseViewModel
    {
        [Column(title: "Фамилия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Surname { get; set; }

        [Column(title: "Имя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Name { get; set; }

        [Column(title: "Отчество", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Patronymic { get; set; }

        [Column(title: "Краткое имя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ShortName { get; set; }

        public List<Guid> TeacherDepartments { get; set; }
    }
}