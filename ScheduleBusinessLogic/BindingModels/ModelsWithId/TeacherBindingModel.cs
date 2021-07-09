using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.BindingModels
{
	public class TeacherBindingModel : BaseBindingModel
    {
        public string Surname { get; set; }
        
        public string Name { get; set; }
        
        public string Patronymic { get; set; }

        public string ShortName { get; set; }

        public List<Guid> TeacherDepartments { get; set; }
    }
}