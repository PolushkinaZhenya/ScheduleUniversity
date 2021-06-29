using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.Interfaces
{
    public interface IAuditoriumService
    {
        List<AuditoriumViewModel> GetList();

        List<AuditoriumViewModel> GetListByEducationalBuilding(string Number);

        AuditoriumViewModel GetElement(Guid? id);

        AuditoriumViewModel GetElementByTitleAndEducationalBuilding(string Ttile, Guid EducationalBuildingId);

        void AddElement(AuditoriumBindingModel model);

        void UpdElement(AuditoriumBindingModel model);

        void DelElement(Guid id);
    }
}
