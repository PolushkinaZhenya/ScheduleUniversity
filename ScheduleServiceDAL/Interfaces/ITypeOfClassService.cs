using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface ITypeOfClassService
    {
        List<TypeOfClassViewModel> GetList();

        TypeOfClassViewModel GetElement(int id);

        void AddElement(TypeOfClassBindingModel model);

        void UpdElement(TypeOfClassBindingModel model);

        void DelElement(int id);

    }
}
