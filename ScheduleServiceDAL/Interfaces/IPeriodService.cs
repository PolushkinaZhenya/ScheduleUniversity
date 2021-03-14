using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface IPeriodService
    {
        List<PeriodViewModel> GetList();

        PeriodViewModel GetElement(Guid id);

        void AddElement(PeriodBindingModel model);

        void UpdElement(PeriodBindingModel model);

        void DelElement(Guid id);
    }
}
