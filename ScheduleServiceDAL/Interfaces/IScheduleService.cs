using ScheduleModel;
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

        List<ScheduleViewModel> GetListByLoadTeacher(Guid? LoadTeacherId);

        ScheduleViewModel GetElement(Guid id);

        ScheduleViewModel GetElementByParamEmpty(Guid PeriodId, int NumberWeeks, Guid StudyGroupId, int? Subgroups, Guid LoadTeacherId);

        ScheduleViewModel GetElementByParamFill(Guid PeriodId, int NumberWeeks, DayOfTheWeek? day, Guid? ClassTimeId, Guid StudyGroupId, int? Subgroups, Guid LoadTeacherId);

        ScheduleViewModel GetIdElementByDayAndClassTime(Guid PeriodId, int NumberWeeks, DayOfTheWeek day, Guid classtimeId, Guid StudyGroupId);

        void AddElement(ScheduleBindingModel model);

        void UpdElement(ScheduleBindingModel model);

        void DelElement(Guid Id);

        List<ScheduleViewModel> GetListByPeriodAndWeekAndStudyGroupSubgroup(Guid PeriodId, int NumberWeek, Guid StudyGroupId);
    }
}
