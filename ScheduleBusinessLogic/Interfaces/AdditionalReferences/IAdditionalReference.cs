using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;

namespace ScheduleServiceDAL.Interfaces.AdditionalReferences
{
	public interface IAdditionalReference<B, V>
        where B : AdditionalReferenceBindingModel
        where V : AdditionalReferenceViewModel
    {
        List<V> GetList();

        V GetElement(Guid id);

        void AddElement(B model);

        void UpdElement(B model);

        void DelElement(Guid id);
    }
}