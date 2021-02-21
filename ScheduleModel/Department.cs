using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //кафедра

    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual List<Auditorium> Auditoriums { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual List<TeacherDepartment> TeacherDepartments { get; set; }
    }
}
