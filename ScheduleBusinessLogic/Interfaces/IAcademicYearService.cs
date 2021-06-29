using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.Interfaces
{
    public interface IAcademicYearService
    {
        List<AcademicYearViewModel> GetList();

        AcademicYearViewModel GetElement(Guid id);

        void AddElement(AcademicYearBindingModel model);

        void UpdElement(AcademicYearBindingModel model);

        void DelElement(Guid id);
    }
}
