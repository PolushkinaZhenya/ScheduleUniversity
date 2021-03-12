using ScheduleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.BindingModels
{
    public class StudyGroupBindingModel
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public int Course { get; set; }
        
        public int NumderStudents { get; set; }
        
        public int NumderSubgroups { get; set; }

        public Guid SpecialtyId { get; set; }

        public TypeEducation TypeEducation { get; set; }

        public FormEducation FormEducation { get; set; }
    }
}
