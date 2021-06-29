using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class TransitionTimeServiceDB : IAdditionalReference<TransitionTimeBindingModel, TransitionTimeViewModel>
    {
        private readonly ScheduleDbContext context;

        public TransitionTimeServiceDB(ScheduleDbContext context)
        {
            this.context = context;
        }

        public List<TransitionTimeViewModel> GetList()
        {
            List<TransitionTimeViewModel> result = context.TransitionTimes.Select
                (rec => new TransitionTimeViewModel
                {
                    Id = rec.Id,
                    EducationalBuildingFrom = rec.EducationalBuildingFrom.Number,
                    EducationalBuildingIdFrom = rec.EducationalBuildingIdFrom,
                    EducationalBuildingTo = rec.EducationalBuildingTo.Number,
                    EducationalBuildingIdTo = rec.EducationalBuildingIdTo,
                    Time = rec.Time
                }).OrderBy(reco => reco.EducationalBuildingFrom)
                .ToList();

            return result;
        }

        public TransitionTimeViewModel GetElement(Guid id)
        {
            TransitionTime element = context.TransitionTimes.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new TransitionTimeViewModel
                {
                    Id = element.Id,
                    Time = element.Time,
                    EducationalBuildingIdFrom = element.EducationalBuildingIdFrom,

                    EducationalBuildingFrom = context.EducationalBuildings
                    .Where(rec => rec.Id == element.EducationalBuildingIdFrom)
                    .Select(rec => rec.Number).FirstOrDefault(),

                    EducationalBuildingIdTo = element.EducationalBuildingIdTo,

                    EducationalBuildingTo = context.EducationalBuildings
                    .Where(rec => rec.Id == element.EducationalBuildingIdTo)
                    .Select(rec => rec.Number).FirstOrDefault()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(TransitionTimeBindingModel model)
        {
            TransitionTime element = context.TransitionTimes.FirstOrDefault
            (rec => rec.EducationalBuildingIdFrom == model.EducationalBuildingIdFrom
            && rec.EducationalBuildingIdTo == model.EducationalBuildingIdTo);

            if (element != null)
            {
                throw new Exception("Уже есть время перехода для этих корпусов");
            }

            context.TransitionTimes.Add(new TransitionTime
            {
                Id = Guid.NewGuid(),
                Time = model.Time,
                EducationalBuildingIdFrom = model.EducationalBuildingIdFrom,
                EducationalBuildingIdTo = model.EducationalBuildingIdTo
            });

            context.SaveChanges();
        }

        public void UpdElement(TransitionTimeBindingModel model)
        {
            TransitionTime element = context.TransitionTimes.FirstOrDefault
            (rec => rec.EducationalBuildingIdFrom == model.EducationalBuildingIdFrom
            && rec.EducationalBuildingIdTo == model.EducationalBuildingIdTo
            && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть время перехода для этих корпусов");
            }

            element = context.TransitionTimes.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Time = model.Time;
            element.EducationalBuildingIdFrom = model.EducationalBuildingIdFrom;
            element.EducationalBuildingIdTo = model.EducationalBuildingIdTo;

            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            TransitionTime element = context.TransitionTimes.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.TransitionTimes.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}