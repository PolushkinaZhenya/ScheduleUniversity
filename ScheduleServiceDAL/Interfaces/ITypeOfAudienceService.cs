using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface ITypeOfAudienceService
    {
        List<TypeOfAudienceViewModel> GetList();

        TypeOfAudienceViewModel GetElement(int id);

        void AddElement(TypeOfAudienceBindingModel model);

        void UpdElement(TypeOfAudienceBindingModel model);

        void DelElement(int id);
    }
}
