using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface IFlowService
    {
        List<FlowViewModel> GetList();

        List<FlowViewModel> GetListNotFlowAutoCreation();

        List<FlowViewModel> GetListNotFlowAutoCreationByStudyGroup(Guid StudyGroupId);

        FlowViewModel GetElement(Guid id);

        FlowViewModel GetElementByTitle(string Title);

        void AddElement(FlowBindingModel model);

        void UpdElement(FlowBindingModel model);

        void DelElement(Guid id);
    }
}
