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
    public class AuditoriumServiceDB : IAuditoriumService
    {
        private AbstractDbContext context;

        public AuditoriumServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<AuditoriumViewModel> GetList()
        {
            List<AuditoriumViewModel> result = context.Auditoriums.Select
                (rec => new AuditoriumViewModel
                {
                    Id = rec.Id,
                    Number = rec.Number,
                    Capacity = rec.Capacity,
                    TypeOfAudience = rec.TypeOfAudience.Title,
                    EducationalBuilding = rec.EducationalBuilding.Number,
                    Department = rec.Department.Title
                }).ToList();

            return result;
        }

        public AuditoriumViewModel GetElement(Guid id)
        {
            Auditorium element = context.Auditoriums.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new AuditoriumViewModel
                {
                    Id = element.Id,
                    Number = element.Number,
                    Capacity = element.Capacity,

                    TypeOfAudienceId = element.TypeOfAudienceId,
                    TypeOfAudience = context.TypeOfAudiences
                    .Where(rec => rec.Id == element.TypeOfAudienceId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    EducationalBuildingId = element.EducationalBuildingId,
                    EducationalBuilding = context.EducationalBuildings
                    .Where(rec => rec.Id == element.EducationalBuildingId)
                    .Select(rec => rec.Number).FirstOrDefault(),

                    DepartmentId = element.DepartmentId,
                    Department = context.Departments
                    .Where(rec => rec.Id == element.DepartmentId)
                    .Select(rec => rec.Title).FirstOrDefault()
                };
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

            context.Auditoriums.Add(new Auditorium
            {
                Id = Guid.NewGuid(),//???
                Number = model.Number,
                Capacity = model.Capacity,
                TypeOfAudienceId = model.TypeOfAudienceId,
                EducationalBuildingId = model.EducationalBuildingId,
                DepartmentId = model.DepartmentId
            });
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

            element.Number = model.Number;
            element.Capacity = model.Capacity;
            element.TypeOfAudienceId = model.TypeOfAudienceId;
            element.EducationalBuildingId = model.EducationalBuildingId;
            element.DepartmentId = model.DepartmentId;

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
    }
}
