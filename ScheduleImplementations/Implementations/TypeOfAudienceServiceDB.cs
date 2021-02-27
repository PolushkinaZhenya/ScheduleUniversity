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
    public class TypeOfAudienceServiceDB : ITypeOfAudienceService
    {
        private AbstractDbContext context;

        public TypeOfAudienceServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<TypeOfAudienceViewModel> GetList()
        {
            List<TypeOfAudienceViewModel> result = context.TypeOfAudiences.Select
                (rec => new TypeOfAudienceViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title
                }).ToList();

            return result;
        }

        public TypeOfAudienceViewModel GetElement(int id)
        {
            TypeOfAudience element = context.TypeOfAudiences.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new TypeOfAudienceViewModel
                {
                    Id = element.Id,
                    Title = element.Title
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(TypeOfAudienceBindingModel model)
        {
            TypeOfAudience element = context.TypeOfAudiences.FirstOrDefault
            (rec => rec.Title == model.Title);

            if (element != null)
            {
                throw new Exception("Уже есть такой тип аудитории");
            }

            context.TypeOfAudiences.Add(new TypeOfAudience
            {
                Title = model.Title
            });

            context.SaveChanges();
        }

        public void UpdElement(TypeOfAudienceBindingModel model)
        {
            TypeOfAudience element = context.TypeOfAudiences.FirstOrDefault
            (rec => rec.Title == model.Title && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такой тип аудитории");
            }

            element = context.TypeOfAudiences.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Title = model.Title;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            TypeOfAudience element = context.TypeOfAudiences.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.TypeOfAudiences.Remove(element);
                context.SaveChanges();
            }

            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
