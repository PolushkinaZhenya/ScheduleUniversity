using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleImplementations.Implementations
{
    public class DepartmentServiceDB : IDepartmentService
    {
        private AbstractDbContext context;

        public DepartmentServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<DepartmentViewModel> GetList()
        {
            List<DepartmentViewModel> result = context.Departments.Select
                (rec => new DepartmentViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    TypeOfDepartment = rec.TypeOfDepartment.Title
                }).OrderBy(reco => reco.Title)
                .ToList();

            return result;
        }

        public DepartmentViewModel GetElement(Guid id)
        {
            Department element = context.Departments.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new DepartmentViewModel
                {
                    Id = element.Id,
                    Title = element.Title,
                    TypeOfDepartmentId = element.TypeOfDepartmentId,

                    TypeOfDepartment = context.TypeOfDepartments
                    .Where(rec => rec.Id == element.TypeOfDepartmentId)
                    .Select(rec => rec.Title).FirstOrDefault()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(DepartmentBindingModel model)
        {
            Department element = context.Departments.FirstOrDefault
            (rec => rec.Title == model.Title);

            if (element != null)
            {
                throw new Exception("Уже есть кафедра с таким названием");
            }

            context.Departments.Add(new Department
            {
                Id = Guid.NewGuid(),//???
                Title = model.Title,
                TypeOfDepartmentId = model.TypeOfDepartmentId
            });
            context.SaveChanges();
        }

        public void UpdElement(DepartmentBindingModel model)
        {
            Department element = context.Departments.FirstOrDefault
            (rec => rec.Title == model.Title && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть кафедра с таким названием");
            }

            element = context.Departments.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Title = model.Title;
            element.TypeOfDepartmentId = model.TypeOfDepartmentId;

            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            Department element = context.Departments.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.Departments.Remove(element);
                context.SaveChanges();
            }

            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
