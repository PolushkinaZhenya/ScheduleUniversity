using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface IScheduleService
    {
        List<ScheduleViewModel> GetList();

        //List<ScheduleViewModel> GetListByPeroidAndType(Guid PeriodId, string Type);

        List<ScheduleViewModel> GetListByPeriodAndWeek(Guid PeriodId, int NumberWeek);
        
        //List<ScheduleViewModel> GetListByLoadTeacherAndWeek(Guid LoadTeacherId, int NumberWeek);

        List<ScheduleViewModel> GetListByPeroidAndStudyGroupEmpty(Guid PeriodId, Guid StudyGroupId);

        List<ScheduleViewModel> GetListByPeroidAndStudyGroupFill(Guid PeriodId, Guid StudyGroupId);

        ScheduleViewModel GetElement(Guid id);

        ScheduleViewModel GetElementByParam(Guid PeriodId, int NumberWeeks, Guid StudyGroupId, int? Subgroups, Guid LoadTeacherId);

        void AddElement(ScheduleBindingModel model);

        void UpdElement(ScheduleBindingModel model);

        void DelElement(Guid id);
    }
}
