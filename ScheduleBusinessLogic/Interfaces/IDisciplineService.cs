using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.Interfaces
{
    public interface IDisciplineService
    {
        List<DisciplineViewModel> GetList();

        DisciplineViewModel GetElement(Guid id);

        void AddElement(DisciplineBindingModel model);

        void UpdElement(DisciplineBindingModel model);

        void DelElement(Guid id);
    }
}
