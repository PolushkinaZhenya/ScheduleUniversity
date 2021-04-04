using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface ILoadTeacherService
    {
        List<LoadTeacherViewModel> GetList();

        List<LoadTeacherViewModel> GetListByTypeAndStudyGroupAndPeriod(string Type, Guid StudyGroup, Guid Peroid);

        LoadTeacherViewModel GetElement(Guid id);

        void AddElement(LoadTeacherBindingModel model);

        void UpdElement(LoadTeacherBindingModel model);

        void DelElement(Guid id);
    }
}
