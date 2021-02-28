using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface ITransitionTimeService
    {
        List<TransitionTimeViewModel> GetList();

        TransitionTimeViewModel GetElement(int id);

        void AddElement(TransitionTimeBindingModel model);

        void UpdElement(TransitionTimeBindingModel model);

        void DelElement(int id);
    }
}
