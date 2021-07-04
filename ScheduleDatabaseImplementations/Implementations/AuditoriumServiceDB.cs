using Microsoft.EntityFrameworkCore;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class AuditoriumServiceDB : IAuditoriumService
    {
        private readonly ScheduleDbContext context;

        public AuditoriumServiceDB(ScheduleDbContext context)
        {
            this.context = context;
        }

		public List<AuditoriumViewModel> GetList() => context.Auditoriums
				.Include(x => x.Department).Include(x => x.EducationalBuilding).Include(x => x.TypeOfAudience)
				.Select(GetViewModel)
				.OrderBy(reco => reco.EducationalBuilding).ThenBy(reco => reco.Number)
				.ToList();

		public List<AuditoriumViewModel> GetListByEducationalBuilding(Guid buildingId) => context.Auditoriums
				.Include(x => x.Department).Include(x => x.EducationalBuilding).Include(x => x.TypeOfAudience)
				.Where(recA => recA.EducationalBuilding.Id == buildingId)
				.Select(GetViewModel)
				.OrderBy(reco => reco.Number)
				.ToList();

		public AuditoriumViewModel GetElement(Guid? id)
        {
            Auditorium element = context.Auditoriums.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return GetViewModel(element);
            }
            throw new Exception("Элемент не найден");
        }

        public AuditoriumViewModel GetElementByTitleAndEducationalBuilding(string Number, Guid EducationalBuildingId)
        {
            Auditorium element = context.Auditoriums.FirstOrDefault(rec => rec.Number == Number && rec.EducationalBuildingId == EducationalBuildingId);

            if (element != null)
            {
                return GetViewModel(element);
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(AuditoriumBindingModel model)
        {
            Auditorium element = context.Auditoriums.FirstOrDefault
            (rec => rec.Number == model.Number && rec.EducationalBuildingId == model.EducationalBuildingId);

            if (element != null)
            {
                throw new Exception("Уже есть такая аудитория в этом корпусе");
            }

            context.Auditoriums.Add(GetModel(model));
            context.SaveChanges();
        }

        public void UpdElement(AuditoriumBindingModel model)
        {
            Auditorium element = context.Auditoriums.FirstOrDefault
            (rec => rec.Number == model.Number && rec.EducationalBuildingId == model.EducationalBuildingId && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такая аудитория в этом корпусе");
            }

            element = context.Auditoriums.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            GetModel(model, element);

            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            Auditorium element = context.Auditoriums.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.Auditoriums.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Auditorium GetModel(AuditoriumBindingModel model, Auditorium element = null)
        {
            if (model == null) return null;
            if (element == null) element = new Auditorium { Id = Guid.NewGuid() };

            element.Number = model.Number;
            element.Capacity = model.Capacity;
            element.TypeOfAudienceId = model.TypeOfAudienceId;
            element.EducationalBuildingId = model.EducationalBuildingId;
            element.DepartmentId = model.DepartmentId;

            return element;
        }

        private static AuditoriumViewModel GetViewModel(Auditorium element)
        {
            if (element == null) return null;
            return new AuditoriumViewModel
            {
                Id = element.Id,
                Number = element.Number,
                Capacity = element.Capacity,
                TypeOfAudienceId = element.TypeOfAudienceId,
                TypeOfAudience = element.TypeOfAudience?.Title,
                EducationalBuildingId = element.EducationalBuildingId,
                EducationalBuilding = element.EducationalBuilding?.Number,
                DepartmentId = element.DepartmentId,
                Department = element.Department?.Title
            };
        }
    }
}