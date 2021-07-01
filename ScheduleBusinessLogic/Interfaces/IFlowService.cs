using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.Interfaces
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