using ScheduleModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
    /// <summary>
    /// тип кафедры
    /// </summary>
    public class TypeOfDepartment
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("TypeOfDepartmentId")]
        public virtual List<Department> Departments { get; set; }
    }
}