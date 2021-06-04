using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //тип кафедры

    public class TypeOfDepartment
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("TypeOfDepartmentId")]
        public virtual List<Department> Departments { get; set; }
    }
}
