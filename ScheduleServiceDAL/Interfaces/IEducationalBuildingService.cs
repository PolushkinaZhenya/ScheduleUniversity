using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface IEducationalBuildingService
    {
        List<EducationalBuildingViewModel> GetList();

        EducationalBuildingViewModel GetElement(int id);

        void AddElement(EducationalBuildingBindingModel model);

        void UpdElement(EducationalBuildingBindingModel model);

        void DelElement(int id);
    }
}
