using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
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
