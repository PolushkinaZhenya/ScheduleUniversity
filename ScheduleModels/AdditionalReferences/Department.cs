using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// кафедра
	/// </summary>
	public class Department : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Guid TypeOfDepartmentId { get; set; }

        public virtual TypeOfDepartment TypeOfDepartment { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual List<Auditorium> Auditoriums { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual List<TeacherDepartment> TeacherDepartments { get; set; }
    }
}