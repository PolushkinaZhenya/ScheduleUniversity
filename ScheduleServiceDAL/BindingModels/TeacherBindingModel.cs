﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.BindingModels
{
    public class TeacherBindingModel
    {
        public int Id { get; set; }
        
        public string Surname { get; set; }
        
        public string Name { get; set; }
        
        public string Patronymic { get; set; }

        public List<TeacherDepartmentBindingModel> TeacherDepartments { get; set; }
    }
}
