using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface ISemesterService
    {
        List<SemesterViewModel> GetList();

        List<SemesterViewModel> GetListByAcademicYear(Guid AcademicYear);

        SemesterViewModel GetElement(Guid id);

        void AddElement(SemesterBindingModel model);

        void UpdElement(SemesterBindingModel model);

        void DelElement(Guid id);
    }
}
