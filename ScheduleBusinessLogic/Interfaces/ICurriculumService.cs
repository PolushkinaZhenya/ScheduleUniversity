using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.Interfaces
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