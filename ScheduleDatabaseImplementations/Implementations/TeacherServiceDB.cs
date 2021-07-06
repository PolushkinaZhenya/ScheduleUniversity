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
	public class TeacherServiceDB : ITeacherService
    {
        private readonly ScheduleDbContext context;

        public TeacherServiceDB(ScheduleDbContext context)
        {
            this.context = context;
        }

		public List<TeacherViewModel> GetList() => context.Teachers
				.Include(x => x.TeacherDepartments)
				.Select(GetViewModel)
				.OrderBy(reco => reco.Surname)
				.ToList();

		public TeacherViewModel GetElement(Guid id)
        {
            Teacher element = context.Teachers
				.Include(x => x.TeacherDepartments)
				.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return GetViewModel(element);
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(TeacherBindingModel model)
        {
			try
			{
				Teacher element = context.Teachers.FirstOrDefault(rec => rec.Surname == model.Surname &&
				rec.Name == model.Name && rec.Patronymic == model.Patronymic);
				if (element != null)
				{
					throw new Exception("Уже есть такой преподаватель");
				}
				element = GetModel(model);
				context.Teachers.Add(element);
				context.SaveChanges();
			}
			catch (Exception)
			{
				throw;
			}
		}

        public void UpdElement(TeacherBindingModel model)
        {
			using var transaction = context.Database.BeginTransaction();
			try
			{
				Teacher element = context.Teachers.FirstOrDefault(rec => rec.Id != model.Id && rec.Surname == model.Surname &&
				rec.Name == model.Name && rec.Patronymic == model.Patronymic);
				if (element != null)
				{
					throw new Exception("Уже есть такой преподаватель");
				}
				element = context.Teachers.FirstOrDefault(rec => rec.Id == model.Id);
				if (element == null)
				{
					throw new Exception("Элемент не найден");
				}
				GetModel(model, element);
				context.SaveChanges();

				var newDepartmentIds = model.TeacherDepartments.Where(x => !element.TeacherDepartments.Any(y => y.DepartmentId == x));
				// добавляем кафедры  
				foreach (var department in newDepartmentIds)
				{
					context.TeacherDepartments.Add(new TeacherDepartment
					{
						Id = Guid.NewGuid(),
						TeacherId = element.Id,
						DepartmentId = department
					});
					context.SaveChanges();
				}

				var deleted = element.TeacherDepartments.Where(x => !model.TeacherDepartments.Any(y => y == x.DepartmentId)).ToList();

				context.TeacherDepartments.RemoveRange(element.TeacherDepartments.Where(x => !model.TeacherDepartments.Any(y => y == x.DepartmentId)));
				context.SaveChanges();

				transaction.Commit();
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
		}

        public void DelElement(Guid id)
        {
			try
			{
				Teacher element = context.Teachers.Include(x => x.TeacherDepartments).FirstOrDefault(rec => rec.Id == id);
				if (element != null)
				{
					context.Teachers.Remove(element);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("Элемент не найден");
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private static Teacher GetModel(TeacherBindingModel model, Teacher element = null)
		{
			if (model == null) return null;
			if (element == null) element = new Teacher { Id = Guid.NewGuid() };

			element.Surname = model.Surname;
			element.Name = model.Name;
			element.Patronymic = model.Patronymic;
			if (element.TeacherDepartments == null)
			{
				element.TeacherDepartments = model.TeacherDepartments.Select(x => new TeacherDepartment
				{
					Id = Guid.NewGuid(),
					DepartmentId = x,
					TeacherId = element.Id
				}).ToList();
			}

			return element;
		}

		private static TeacherViewModel GetViewModel(Teacher element)
		{
			if (element == null) return null;
			return new TeacherViewModel
			{
				Id = element.Id,
				Surname = element.Surname,
				Name = element.Name,
				Patronymic = element.Patronymic,
				TeacherDepartments = element.TeacherDepartments.Select(rec => rec.DepartmentId).ToList()
			};
		}
	}
}