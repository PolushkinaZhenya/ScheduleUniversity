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
    public class AcademicYearServiceDB : IAcademicYearService
    {
        private AbstractDbContext context;

        public AcademicYearServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<AcademicYearViewModel> GetList()
        {
            List<AcademicYearViewModel> result = context.AcademicYears.Select
                (rec => new AcademicYearViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title
                })
            .ToList();

            return result;
        }

        public AcademicYearViewModel GetElement(Guid id)
        {
            AcademicYear element = context.AcademicYears.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new AcademicYearViewModel
                {
                    Id = element.Id,
                    Title = element.Title
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(AcademicYearBindingModel model)
        {
            AcademicYear element = context.AcademicYears.FirstOrDefault
            (rec => rec.Title == model.Title);

            if (element != null)
            {
                throw new Exception("Уже есть такой учебный год");
            }

            context.AcademicYears.Add(new AcademicYear
            {
                Id = Guid.NewGuid(),//???
                Title = model.Title
            });

            context.SaveChanges();
        }

        public void UpdElement(AcademicYearBindingModel model)
        {
            AcademicYear element = context.AcademicYears.FirstOrDefault
            (rec => rec.Title == model.Title && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такой учебный год");
            }

            element = context.AcademicYears.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Title = model.Title;
            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            AcademicYear element = context.AcademicYears.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.AcademicYears.Remove(element);
                context.SaveChanges();
            }

            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
