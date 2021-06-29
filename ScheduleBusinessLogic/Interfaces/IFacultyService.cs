using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.Interfaces
{
    public interface IFacultyService
    {
        List<FacultyViewModel> GetList();

        FacultyViewModel GetElement(Guid id);

        FacultyViewModel GetElementByTitle(string Title);

        void AddElement(FacultyBindingModel model);

        void UpdElement(FacultyBindingModel model);

        void DelElement(Guid id);
    }
}
