using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface IStudyGroupService
    {
        List<StudyGroupViewModel> GetList();

        List<StudyGroupViewModel> GetListByCourse(int Course);

        List<StudyGroupViewModel> GetListCourse();

        StudyGroupViewModel GetElement(Guid id);

        StudyGroupViewModel GetElementByTitle(string Title);

        void AddElement(StudyGroupBindingModel model);

        void UpdElement(StudyGroupBindingModel model);

        void DelElement(Guid id);
    }
}
