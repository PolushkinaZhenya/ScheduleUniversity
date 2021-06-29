using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.Interfaces
{
    public interface IEducationalBuildingService
    {
        List<EducationalBuildingViewModel> GetList();

        EducationalBuildingViewModel GetElement(Guid id);

        EducationalBuildingViewModel GetElementByNumder(string Number);

        void AddElement(EducationalBuildingBindingModel model);

        void UpdElement(EducationalBuildingBindingModel model);

        void DelElement(Guid id);
    }
}
