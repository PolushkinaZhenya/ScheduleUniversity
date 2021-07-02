using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.Interfaces
{
	public interface IAuditoriumService
    {
        List<AuditoriumViewModel> GetList();

        List<AuditoriumViewModel> GetListByEducationalBuilding(Guid buildingId);

        AuditoriumViewModel GetElement(Guid? id);

        AuditoriumViewModel GetElementByTitleAndEducationalBuilding(string Ttile, Guid EducationalBuildingId);

        void AddElement(AuditoriumBindingModel model);

        void UpdElement(AuditoriumBindingModel model);

        void DelElement(Guid id);
    }
}