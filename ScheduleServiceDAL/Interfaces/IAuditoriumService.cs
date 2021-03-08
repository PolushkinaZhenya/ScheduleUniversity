using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface IAuditoriumService
    {
        List<AuditoriumViewModel> GetList();

        AuditoriumViewModel GetElement(Guid id);

        void AddElement(AuditoriumBindingModel model);

        void UpdElement(AuditoriumBindingModel model);

        void DelElement(Guid id);
    }
}
