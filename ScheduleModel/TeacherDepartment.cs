using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //связь преподаватель - кафедра

    public class TeacherDepartment
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public int DepartmentId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Department Department { get; set; }
    }
}
