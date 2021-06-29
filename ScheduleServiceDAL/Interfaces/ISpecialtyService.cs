using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.Interfaces
{
    public interface ISpecialtyService
    {
        List<SpecialtyViewModel> GetList();

        SpecialtyViewModel GetElement(Guid id);

        List<SpecialtyViewModel> GetListByFaculty(Guid facultyId);

        void AddElement(SpecialtyBindingModel model);

        void UpdElement(SpecialtyBindingModel model);

        void DelElement(Guid id);
    }
}
