﻿using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.Interfaces
{
	public interface ITeacherService
    {
        List<TeacherViewModel> GetList();

        TeacherViewModel GetElement(Guid id);

        void AddElement(TeacherBindingModel model);

        void UpdElement(TeacherBindingModel model);

        void DelElement(Guid id);
    }
}