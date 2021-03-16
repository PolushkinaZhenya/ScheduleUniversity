using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface IScheduleService
    {
        List<ScheduleViewModel> GetList();

        ScheduleViewModel GetElement(Guid id);

        void AddElement(ScheduleBindingModel model);

        void UpdElement(ScheduleBindingModel model);

        void DelElement(Guid id);
    }
}
