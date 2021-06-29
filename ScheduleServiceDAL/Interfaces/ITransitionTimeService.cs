using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.Interfaces
{
    public interface ITransitionTimeService
    {
        List<TransitionTimeViewModel> GetList();

        TransitionTimeViewModel GetElement(Guid id);

        void AddElement(TransitionTimeBindingModel model);

        void UpdElement(TransitionTimeBindingModel model);

        void DelElement(Guid id);
    }
}
