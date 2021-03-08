using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //преподаватель

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
    }
}
