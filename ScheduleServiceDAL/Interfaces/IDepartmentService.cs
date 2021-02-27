using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface IDepartmentService
    {
        List<DepartmentViewModel> GetList();

        DepartmentViewModel GetElement(int id);

        void AddElement(DepartmentBindingModel model);

        void UpdElement(DepartmentBindingModel model);

        void DelElement(int id);
    }
}
