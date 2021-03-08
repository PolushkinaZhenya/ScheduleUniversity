using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface ITypeOfDepartmentService
    {
        List<TypeOfDepartmentViewModel> GetList();

        TypeOfDepartmentViewModel GetElement(Guid id);

        void AddElement(TypeOfDepartmentBindingModel model);

        void UpdElement(TypeOfDepartmentBindingModel model);

        void DelElement(Guid id);
    }
}
