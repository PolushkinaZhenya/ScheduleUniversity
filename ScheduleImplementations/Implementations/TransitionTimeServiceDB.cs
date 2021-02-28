using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    EducationalBuildingFrom = rec.EducationalBuilding.Number,
                    Time = rec.Time
                    //добавить
                }).ToList();

            return result;
        }

        public TransitionTimeViewModel GetElement(int id)
        {
            TransitionTime element = context.TransitionTimes.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new TransitionTimeViewModel
                {
                    Id = element.Id,
                    Time = element.Time,
                    EducationalBuildingId = element.EducationalBuildingId,

                    EducationalBuildingFrom = context.EducationalBuildings
                    .Where(rec => rec.Id == element.EducationalBuildingId)
                    .Select(rec => rec.Number).FirstOrDefault()
                    //добавить
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(TransitionTimeBindingModel model)
        {
            TransitionTime element = context.TransitionTimes.FirstOrDefault
            (rec => rec.EducationalBuildingId == model.EducationalBuildingId ); //добавить 2й корпус

            if (element != null)
            {
                throw new Exception("Уже есть время перехода для этих корпусов");
            }

            context.TransitionTimes.Add(new TransitionTime
            {
                Time = model.Time,
                EducationalBuildingId = model.EducationalBuildingId
                //добавить
            });

            context.SaveChanges();
        }

        public void UpdElement(TransitionTimeBindingModel model)
        {
            TransitionTime element = context.TransitionTimes.FirstOrDefault
            (rec => rec.EducationalBuildingId == model.EducationalBuildingId && rec.Id != model.Id);//добавить 2й корпус

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
            element.EducationalBuildingId = model.EducationalBuildingId;
            //добавить

            context.SaveChanges();
        }

        public void DelElement(int id)
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
