using ScheduleModel;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
    public class SemesterServiceDB : ISemesterService
    {
        private AbstractDbContext context;

        public SemesterServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<SemesterViewModel> GetList()
        {
            List<SemesterViewModel> result = context.Semesters.Select
                (rec => new SemesterViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    AcademicYearTitle = rec.AcademicYear.Title
                }).OrderBy(reco => reco.Title)
                .ToList();

            return result;
        }

        public List<SemesterViewModel> GetListByAcademicYear(Guid AcademicYearId)
        {
            List<SemesterViewModel> result = context.Semesters
                .Where(rec => rec.AcademicYearId == AcademicYearId)
                .Select
                (rec => new SemesterViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title
                }).ToList();

            return result;
        }

        public SemesterViewModel GetElement(Guid id)
        {
            Semester element = context.Semesters.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new SemesterViewModel
                {
                    Id = element.Id,
                    Title = element.Title,

                    AcademicYearId = element.AcademicYearId,
                    AcademicYearTitle = context.AcademicYears
                    .Where(rec => rec.Id == element.AcademicYearId)
                    .Select(rec => rec.Title).FirstOrDefault()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(SemesterBindingModel model)
        {
            Semester element = context.Semesters.FirstOrDefault
            (rec => rec.Title == model.Title && rec.AcademicYearId == model.AcademicYearId);

            if (element != null)
            {
                throw new Exception("Уже есть такой семестер в этом учебном году");
            }

            context.Semesters.Add(new Semester
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                AcademicYearId = model.AcademicYearId
            });
            context.SaveChanges();
        }

        public void UpdElement(SemesterBindingModel model)
        {
            Semester element = context.Semesters.FirstOrDefault
            (rec => rec.Title == model.Title && rec.AcademicYearId == model.AcademicYearId && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такой семестер в этом учебном году");
            }

            element = context.Semesters.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Title = model.Title;
            element.AcademicYearId = model.AcademicYearId;

            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            Semester element = context.Semesters.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.Semesters.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
