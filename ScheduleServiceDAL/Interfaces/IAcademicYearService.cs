using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
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
