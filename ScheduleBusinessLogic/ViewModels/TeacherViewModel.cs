using ScheduleBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ScheduleBusinessLogic.ViewModels
{
	public class TeacherViewModel
    {
        [Column(title: "id", visible: false)]
        public Guid Id { get; set; }

        [Column(title: "Фамилия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Surname { get; set; }

        [Column(title: "Имя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Name { get; set; }

        [Column(title: "Отчество", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Patronymic { get; set; }

        public List<Guid> TeacherDepartments { get; set; }
    }
}