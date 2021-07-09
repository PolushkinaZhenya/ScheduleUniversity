using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.Interfaces
{
	public interface IAuditoriumService : IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel>
    {
        List<AuditoriumViewModel> GetListByEducationalBuilding(Guid buildingId);

        AuditoriumViewModel GetElementByTitleAndEducationalBuilding(string Ttile, Guid EducationalBuildingId);
    }
}