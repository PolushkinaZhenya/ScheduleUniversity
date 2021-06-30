using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class SpecialtyServiceDB : IAdditionalReference<SpecialtyBindingModel, SpecialtyViewModel>
    {
        private readonly ScheduleDbContext context;

        public SpecialtyServiceDB(ScheduleDbContext context)
        {
            this.context = context;
        }

        public List<SpecialtyViewModel> GetList()
        {
            List<SpecialtyViewModel> result = context.Specialties.Select
                (rec => new SpecialtyViewModel
                {
                    Id = rec.Id,
                    Code = rec.Code,
                    Title = rec.Title,
                    AbbreviatedTitle = rec.AbbreviatedTitle,
                    FacultyTitle = rec.Faculty.Title
                }).OrderBy(reco => reco.Title)
                .ToList();

            return result;
        }

        public SpecialtyViewModel GetElement(Guid id)
        {
            Specialty element = context.Specialties.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new SpecialtyViewModel
                {
                    Id = element.Id,
                    Code = element.Code,
                    Title = element.Title,
                    AbbreviatedTitle = element.AbbreviatedTitle,

                    FacultyId = element.FacultyId,
                    FacultyTitle = context.Faculties
                    .Where(rec => rec.Id == element.FacultyId)
                    .Select(rec => rec.Title).FirstOrDefault()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(SpecialtyBindingModel model)
        {
            Specialty element = context.Specialties.FirstOrDefault
            (rec => rec.Title == model.Title);

            if (element != null)
            {
                throw new Exception("Уже есть такая специальность");
            }

            context.Specialties.Add(new Specialty
            {
                Id = Guid.NewGuid(),
                Code = model.Code,
                Title = model.Title,
                AbbreviatedTitle = model.AbbreviatedTitle,
                FacultyId = model.FacultyId
            });
            context.SaveChanges();
        }

        public void UpdElement(SpecialtyBindingModel model)
        {
            Specialty element = context.Specialties.FirstOrDefault
            (rec => rec.Title == model.Title && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такая специальность");
            }

            element = context.Specialties.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Code = model.Code;
            element.Title = model.Title;
            element.AbbreviatedTitle = model.AbbreviatedTitle;
            element.FacultyId = model.FacultyId;

            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            Specialty element = context.Specialties.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.Specialties.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}