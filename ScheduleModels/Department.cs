using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ScheduleModels;

namespace ScheduleModel
{
    //кафедра

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
