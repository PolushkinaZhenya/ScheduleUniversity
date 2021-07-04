using ScheduleModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// преподаватель
	/// </summary>
	public class Teacher
    {
        public Guid Id { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [ForeignKey("TeacherId")]
        public virtual List<TeacherDepartment> TeacherDepartments { get; set; }

        [ForeignKey("TeacherId")]
        public virtual List<Schedule> Schedules { get; set; }

        [ForeignKey("TeacherId")]
        public virtual List<LoadTeacher> LoadTeachers { get; set; }
    }
}
