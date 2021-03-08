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
    public class TypeOfDepartmentServiceDB : ITypeOfDepartmentService
    {
        private AbstractDbContext context;

        public TypeOfDepartmentServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<TypeOfDepartmentViewModel> GetList()
        {
            List<TypeOfDepartmentViewModel> result = context.TypeOfDepartments.Select
                (rec => new TypeOfDepartmentViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title
                })
            .ToList();

            return result;
        }

        public TypeOfDepartmentViewModel GetElement(Guid id)
        {
            TypeOfDepartment element = context.TypeOfDepartments.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new TypeOfDepartmentViewModel
                {
                    Id = element.Id,
                    Title = element.Title
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(TypeOfDepartmentBindingModel model)
        {
            TypeOfDepartment element = context.TypeOfDepartments.FirstOrDefault
            (rec => rec.Title == model.Title);

            if (element != null)
            {
                throw new Exception("Уже есть такой тип кафедры");
            }

            context.TypeOfDepartments.Add(new TypeOfDepartment
            {
                Id = Guid.NewGuid(),//???
                Title = model.Title
            });

            context.SaveChanges();
        }

        public void UpdElement(TypeOfDepartmentBindingModel model)
        {
            TypeOfDepartment element = context.TypeOfDepartments.FirstOrDefault
            (rec => rec.Title == model.Title && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такой тип кафедры");
            }

            element = context.TypeOfDepartments.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Title = model.Title;
            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            TypeOfDepartment element = context.TypeOfDepartments.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.TypeOfDepartments.Remove(element);
                context.SaveChanges();
            }

            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
