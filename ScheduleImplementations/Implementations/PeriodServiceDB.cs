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
    public class PeriodServiceDB : IPeriodService
    {
        private AbstractDbContext context;

        public PeriodServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<PeriodViewModel> GetList()
        {
            List<PeriodViewModel> result = context.Periods.Select
                (rec => new PeriodViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    StartDate = rec.StartDate,
                    EndDate = rec.EndDate,
                    SemesterTitle = rec.Semester.Title
                }).ToList();

            return result;
        }
        public List<PeriodViewModel> GetListBySemester(Guid SemesterId)
        {
            List<PeriodViewModel> result = context.Periods
                .Where(rec => rec.SemesterId == SemesterId)
                .Select(rec => new PeriodViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title
                }).ToList();

            return result;
        }

        public PeriodViewModel GetElement(Guid id)
        {
            Period element = context.Periods.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new PeriodViewModel
                {
                    Id = element.Id,
                    Title = element.Title,
                    StartDate = element.StartDate,
                    EndDate = element.EndDate,

                    SemesterId = element.SemesterId,
                    SemesterTitle = context.Semesters
                    .Where(rec => rec.Id == element.SemesterId)
                    .Select(rec => rec.Title).FirstOrDefault()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(PeriodBindingModel model)
        {
            Period element = context.Periods.FirstOrDefault
            (rec => rec.Title == model.Title && rec.SemesterId == model.SemesterId);

            if (element != null)
            {
                throw new Exception("Уже есть такой период в этом семестре");
            }

            context.Periods.Add(new Period
            {
                Id = Guid.NewGuid(),//???
                Title = model.Title,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                SemesterId = model.SemesterId
            });
            context.SaveChanges();
        }

        public void UpdElement(PeriodBindingModel model)
        {
            Period element = context.Periods.FirstOrDefault
            (rec => rec.Title == model.Title && rec.SemesterId == model.SemesterId && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такой период в этом семестре");
            }

            element = context.Periods.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Title = model.Title;
            element.StartDate = model.StartDate;
            element.EndDate = model.EndDate;
            element.SemesterId = model.SemesterId;

            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            Period element = context.Periods.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.Periods.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
