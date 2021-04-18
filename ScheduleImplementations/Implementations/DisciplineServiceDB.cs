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
    public class DisciplineServiceDB : IDisciplineService
    {
        private AbstractDbContext context;

        public DisciplineServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<DisciplineViewModel> GetList()
        {
            List<DisciplineViewModel> result = context.Disciplines.Select
                (rec => new DisciplineViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    AbbreviatedTitle = rec.AbbreviatedTitle
                }).OrderBy(reco => reco.Title)
            .ToList();

            return result;
        }

        public DisciplineViewModel GetElement(Guid id)
        {
            Discipline element = context.Disciplines.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new DisciplineViewModel
                {
                    Id = element.Id,
                    Title = element.Title,
                    AbbreviatedTitle = element.AbbreviatedTitle
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(DisciplineBindingModel model)
        {
            Discipline element = context.Disciplines.FirstOrDefault
            (rec => rec.Title == model.Title);

            if (element != null)
            {
                throw new Exception("Уже есть такая дисциплина");
            }

            context.Disciplines.Add(new Discipline
            {
                Id = Guid.NewGuid(),//???
                Title = model.Title,
                AbbreviatedTitle = model.AbbreviatedTitle
            });

            context.SaveChanges();
        }

        public void UpdElement(DisciplineBindingModel model)
        {
            Discipline element = context.Disciplines.FirstOrDefault
            (rec => rec.Title == model.Title && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такая дисциплина");
            }

            element = context.Disciplines.FirstOrDefault(rec => rec.Id == model.Id);

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
            Discipline element = context.Disciplines.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.Disciplines.Remove(element);
                context.SaveChanges();
            }

            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
