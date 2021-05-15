using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleImplementations.Implementations
{
    public class ClassTimeServiceDB : IClassTimeService
    {
        private AbstractDbContext context;

        public ClassTimeServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<ClassTimeViewModel> GetList()
        {
            List<ClassTimeViewModel> result = context.ClassTimes.Select
                (rec => new ClassTimeViewModel
                {
                    Id = rec.Id,
                    Number = rec.Number,
                    StartTime = rec.StartTime,
                    EndTime = rec.EndTime

                }).OrderBy(reco => reco.Number).ToList();

            return result;
        }

        public ClassTimeViewModel GetElement(Guid id)
        {
            ClassTime element = context.ClassTimes.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new ClassTimeViewModel
                {
                    Id = element.Id,
                    Number = element.Number,
                    StartTime = element.StartTime,
                    EndTime = element.EndTime
                };
            }

            throw new Exception("Элемент не найден");
        }

        //по номеру пары
        public ClassTimeViewModel GetElementByNumber(int Number)
        {
            ClassTime element = context.ClassTimes.FirstOrDefault(rec => rec.Number == Number);

            if (element != null)
            {
                return new ClassTimeViewModel
                {
                    Id = element.Id,
                    Number = element.Number,
                    StartTime = element.StartTime,
                    EndTime = element.EndTime
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(ClassTimeBindingModel model)
        {
            ClassTime element = context.ClassTimes.FirstOrDefault
            (rec => rec.Number == model.Number);

            if (element != null)
            {
                throw new Exception("Уже есть время для этой пары");
            }

            context.ClassTimes.Add(new ClassTime
            {
                Id = Guid.NewGuid(),//???
                Number = model.Number,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            });

            context.SaveChanges();
        }

        public void UpdElement(ClassTimeBindingModel model)
        {
            ClassTime element = context.ClassTimes.FirstOrDefault
            (rec => rec.Number == model.Number && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть время для этой пары");
            }

            element = context.ClassTimes.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Number = model.Number;
            element.StartTime = model.StartTime;
            element.EndTime = model.EndTime;
            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            ClassTime element = context.ClassTimes.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.ClassTimes.Remove(element);
                context.SaveChanges();
            }

            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
