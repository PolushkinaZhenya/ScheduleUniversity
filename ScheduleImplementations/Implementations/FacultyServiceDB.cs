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
    public class FacultyServiceDB : IFacultyService
    {
        private AbstractDbContext context;

        public FacultyServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<FacultyViewModel> GetList()
        {
            List<FacultyViewModel> result = context.Faculties.Select
                (rec => new FacultyViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title
                })
            .ToList();

            return result;
        }

        public FacultyViewModel GetElement(Guid id)
        {
            Faculty element = context.Faculties.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new FacultyViewModel
                {
                    Id = element.Id,
                    Title = element.Title
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(FacultyBindingModel model)
        {
            Faculty element = context.Faculties.FirstOrDefault
            (rec => rec.Title == model.Title);

            if (element != null)
            {
                throw new Exception("Уже есть такой факультет");
            }

            context.Faculties.Add(new Faculty
            {
                Id = Guid.NewGuid(),//???
                Title = model.Title
            });

            context.SaveChanges();
        }

        public void UpdElement(FacultyBindingModel model)
        {
            Faculty element = context.Faculties.FirstOrDefault
            (rec => rec.Title == model.Title && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такой факультет");
            }

            element = context.Faculties.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Title = model.Title;
            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            Faculty element = context.Faculties.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.Faculties.Remove(element);
                context.SaveChanges();
            }

            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
