using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface IClassTimeService
    {
        List<ClassTimeViewModel> GetList();

        ClassTimeViewModel GetElement(Guid id);

        ClassTimeViewModel GetElementByNumber(int Number);

        void AddElement(ClassTimeBindingModel model);

        void UpdElement(ClassTimeBindingModel model);

        void DelElement(Guid id);
    }
}
