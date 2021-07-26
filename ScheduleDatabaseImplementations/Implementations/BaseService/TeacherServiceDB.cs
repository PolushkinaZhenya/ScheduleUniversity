using Microsoft.EntityFrameworkCore;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class TeacherServiceDB : AbstractServiceDB<TeacherBindingModel, TeacherViewModel, TeacherSearchModel, Teacher>,
		IBaseService<TeacherBindingModel, TeacherViewModel, TeacherSearchModel>
	{
        public TeacherServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<Teacher> Ordering(IQueryable<Teacher> query) =>
			query.OrderBy(x => x.Surname).ThenBy(x => x.Name).ThenBy(x => x.Patronymic);

		protected override IQueryable<Teacher> Including(IQueryable<Teacher> query) =>
			query.Include(x => x.TeacherDepartments);

		protected override IQueryable<Teacher> FilteringList(IQueryable<Teacher> query, TeacherSearchModel model)
		{
			if (model.Name.IsNotEmpty())
			{
				query = query.Where(x => x.Name.Contains(model.Name));
			}
			if (model.Surname.IsNotEmpty())
			{
				query = query.Where(x => x.Surname.Contains(model.Surname));
			}
			if (model.Patronymic.IsNotEmpty())
			{
				query = query.Where(x => x.Patronymic.Contains(model.Patronymic));
			}
			if (model.SurnameFirstLetter.IsNotEmpty())
			{
				query = query.Where(x => x.Surname.StartsWith(model.SurnameFirstLetter));
			}

			return query;
		}

		protected override Teacher FilteringSingle(IQueryable<Teacher> query, TeacherSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.ShortName.IsNotEmpty())
			{
				query = query.Where(x => x.ShortName == model.ShortName);
			}

			return query?.FirstOrDefault();
		}

		protected override Func<Teacher, bool> AdditionalCheckingWhenAdding(TeacherBindingModel model) =>
			x => x.Surname == model.Surname && x.Name == model.Name && x.Patronymic == model.Patronymic && x.ShortName != model.ShortName;

		protected override Func<Teacher, bool> AdditionalCheckingWhenUpdateing(TeacherBindingModel model) =>
			x => x.Surname == model.Surname && x.Name == model.Name && x.Patronymic == model.Patronymic && x.ShortName != model.ShortName && x.Id != model.Id;

		protected override IQueryable<Teacher> GetListForDelete(IQueryable<Teacher> query, TeacherSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.ShortName.IsNotEmpty())
			{
				query = query.Where(x => x.ShortName == model.ShortName);
			}

			return query;
		}

		protected override TeacherViewModel ConvertToViewModel(Teacher entity) =>
			new()
			{
				Id = entity.Id,
				ShortName = entity.ShortName,
				Surname = entity.Surname,
				Name = entity.Name,
				Patronymic = entity.Patronymic,
				TeacherDepartments = entity.TeacherDepartments?.Select(x => x.DepartmentId)?.ToList()
			};

		protected override Teacher ConvertToEntityModel(TeacherBindingModel model, Teacher element)
		{
			element.ShortName = model.ShortName;
			element.Surname = model.Surname;
			element.Name = model.Name;
			element.Patronymic = model.Patronymic;

			return element;
		}

		protected override void AdditionalActionsOnAddition(ScheduleDbContext context, TeacherBindingModel model, Teacher element)
		{
			base.AdditionalActionsOnAddition(context, model, element);

			// добавляем кафедры  
			foreach (var department in model.TeacherDepartments.Distinct())
			{
				context.TeacherDepartments.Add(new TeacherDepartment
				{
					Id = Guid.NewGuid(),
					TeacherId = element.Id,
					DepartmentId = department
				});
				context.SaveChanges();
			}
		}

		protected override void AdditionalActionsOnUpdate(ScheduleDbContext context, TeacherBindingModel model, Teacher element)
		{
			base.AdditionalActionsOnUpdate(context, model, element);

			var exsistDeps = context.TeacherDepartments.Where(x => x.TeacherId == element.Id);

			var newDepartmentIds = model.TeacherDepartments.Where(x => !exsistDeps.Any(y => y.DepartmentId == x));
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

			context.TeacherDepartments.RemoveRange(exsistDeps.Where(x => !model.TeacherDepartments.Any(y => y == x.DepartmentId)));
			context.SaveChanges();
		}
	}
}