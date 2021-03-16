﻿using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface ICurriculumService
    {
        List<CurriculumViewModel> GetList();

        CurriculumViewModel GetElement(Guid id);

        void AddElement(CurriculumBindingModel model);

        void UpdElement(CurriculumBindingModel model);

        void DelElement(Guid id);
    }
}
