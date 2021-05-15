using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleImplementations.Implementations
{
    public class TransitionTimeServiceDB : ITransitionTimeService
    {
        private AbstractDbContext context;

        public TransitionTimeServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<TransitionTimeViewModel> GetList()
        {
            List<TransitionTimeViewModel> result = context.TransitionTimes.Select
                (rec => new TransitionTimeViewModel
                {
                    Id = rec.Id,

                    EducationalBuildingFrom = context.EducationalBuildings
                    .Where(rec1 => rec1.Id == rec.EducationalBuildingId_1)
                    .Select(rec1 => rec1.Number).FirstOrDefault(),

                    EducationalBuildingTo = context.EducationalBuildings
                    .Where(rec1 => rec1.Id == rec.EducationalBuildingId_2)
                    .Select(rec1 => rec1.Number).FirstOrDefault(),
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
                    EducationalBuildingId_1 = element.EducationalBuildingId_1,

                    EducationalBuildingFrom = context.EducationalBuildings
                    .Where(rec => rec.Id == element.EducationalBuildingId_1)
                    .Select(rec => rec.Number).FirstOrDefault(),

                    EducationalBuildingId_2 = element.EducationalBuildingId_2,

                    EducationalBuildingTo = context.EducationalBuildings
                    .Where(rec => rec.Id == element.EducationalBuildingId_2)
                    .Select(rec => rec.Number).FirstOrDefault()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(TransitionTimeBindingModel model)
        {
            TransitionTime element = context.TransitionTimes.FirstOrDefault
            (rec => rec.EducationalBuildingId_1 == model.EducationalBuildingId_1
            && rec.EducationalBuildingId_2 == model.EducationalBuildingId_2);

            if (element != null)
            {
                throw new Exception("Уже есть время перехода для этих корпусов");
            }

            context.TransitionTimes.Add(new TransitionTime
            {
                Id = Guid.NewGuid(),
                Time = model.Time,
                EducationalBuildingId_1 = model.EducationalBuildingId_1,
                EducationalBuildingId_2 = model.EducationalBuildingId_2
            });

            context.SaveChanges();
        }

        public void UpdElement(TransitionTimeBindingModel model)
        {
            TransitionTime element = context.TransitionTimes.FirstOrDefault
            (rec => rec.EducationalBuildingId_1 == model.EducationalBuildingId_1
            && rec.EducationalBuildingId_2 == model.EducationalBuildingId_2
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
            element.EducationalBuildingId_1 = model.EducationalBuildingId_1;
            element.EducationalBuildingId_2 = model.EducationalBuildingId_2;

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
