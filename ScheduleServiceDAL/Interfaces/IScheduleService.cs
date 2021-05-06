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
        //List<ScheduleViewModel> GetList();

        List<ScheduleViewModel> GetListByPeriodAndWeek(Guid PeriodId, int NumberWeek, string Type);

        List<ScheduleViewModel> GetListByPeriodAndWeekAndStudyGroupSubgroup(Guid PeriodId, int NumberWeek, Guid StudyGroupId, string Type);

        List<ScheduleViewModel> GetListByPeroidAndStudyGroupEmpty(Guid PeriodId, Guid StudyGroupId, string Type);

        List<ScheduleViewModel> GetListByPeroidAndStudyGroupFill(Guid PeriodId, Guid StudyGroupId, string Type);

        List<ScheduleViewModel> GetListByPeroidAndAuditoriumClose(Guid PeriodId, Guid AuditoriumId, string Type);

        List<ScheduleViewModel> GetListByPeroidAndAuditoriumFill(Guid PeriodId, Guid AuditoriumId, string Type);

        List<ScheduleViewModel> GetListByLoadTeacher(Guid? LoadTeacherId, string Type);

        ScheduleViewModel GetElement(Guid id);

        ScheduleViewModel GetElementByParamEmpty(Guid PeriodId, int NumberWeeks, Guid StudyGroupId, int? Subgroups, Guid? LoadTeacherId, string Type);

        ScheduleViewModel GetElementByParamFill(Guid PeriodId, int NumberWeeks, DayOfTheWeek? day, Guid? ClassTimeId, Guid StudyGroupId, int? Subgroups, Guid? LoadTeacherId, string Type);

        ScheduleViewModel GetElementByDayAndClassTimeAndStudyGroupId(Guid PeriodId, int NumberWeeks, DayOfTheWeek day, Guid classtimeId, Guid StudyGroupId, string Type);

        ScheduleViewModel GetElementByDayAndClassTimeAndAuditoriumId(Guid PeriodId, int NumberWeeks, DayOfTheWeek day, Guid classtimeId, Guid AuditoriumId, string Type);
        
        void AddElement(ScheduleBindingModel model);

        void UpdElement(ScheduleBindingModel model);

        void DelElement(Guid Id);
    }
}
