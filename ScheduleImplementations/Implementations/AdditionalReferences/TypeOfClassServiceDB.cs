using ScheduleModel;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class TypeOfClassServiceDB : IAdditionalReference<TypeOfClassBindingModel, TypeOfClassViewModel>
    {
        private readonly AbstractDbContext context;

        public TypeOfClassServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<TypeOfClassViewModel> GetList()
        {
            List<TypeOfClassViewModel> result = context.TypeOfClasses.Select
                (rec => new TypeOfClassViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    AbbreviatedTitle = rec.AbbreviatedTitle
                })
                .OrderBy(reco => reco.AbbreviatedTitle)
                .ToList();

            return result;
        }

        public TypeOfClassViewModel GetElement(Guid id)
        {
            TypeOfClass element = context.TypeOfClasses.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new TypeOfClassViewModel
                {
                    Id = element.Id,
                    Title = element.Title,
                    AbbreviatedTitle = element.AbbreviatedTitle
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(TypeOfClassBindingModel model)
        {
            TypeOfClass element = context.TypeOfClasses.FirstOrDefault
            (rec => rec.Title == model.Title);

            if (element != null)
            {
                throw new Exception("Уже есть такой тип занятия");
            }

            context.TypeOfClasses.Add(new TypeOfClass
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                AbbreviatedTitle = model.AbbreviatedTitle
            });

            context.SaveChanges();
        }

        public void UpdElement(TypeOfClassBindingModel model)
        {
            TypeOfClass element = context.TypeOfClasses.FirstOrDefault
            (rec => rec.Title == model.Title && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такой тип занятия");
            }

            element = context.TypeOfClasses.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Title = model.Title;
            element.AbbreviatedTitle = model.AbbreviatedTitle;
            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            TypeOfClass element = context.TypeOfClasses.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.TypeOfClasses.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
