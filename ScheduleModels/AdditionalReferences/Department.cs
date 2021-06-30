using ScheduleModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
    /// <summary>
    /// кафедра
    /// </summary>
    public class Department
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public Guid TypeOfDepartmentId { get; set; }

        public virtual TypeOfDepartment TypeOfDepartment { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual List<Auditorium> Auditoriums { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual List<TeacherDepartment> TeacherDepartments { get; set; }
    }
}