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
	public class TypeOfDepartmentServiceDB : AbstractServiceDB<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel, TypeOfDepartmentSearchModel, TypeOfDepartment>,
		IBaseService<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel, TypeOfDepartmentSearchModel>
	{
		public TypeOfDepartmentServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<TypeOfDepartment> Ordering(IQueryable<TypeOfDepartment> query) =>
			query.OrderBy(x => x.Title);

		protected override IQueryable<TypeOfDepartment> Including(IQueryable<TypeOfDepartment> query) =>
			query;

		protected override IQueryable<TypeOfDepartment> FilteringList(IQueryable<TypeOfDepartment> query, TypeOfDepartmentSearchModel model)
		{
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}

			return query;
		}

		protected override TypeOfDepartment FilteringSingle(IQueryable<TypeOfDepartment> query, TypeOfDepartmentSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}

			return query?.FirstOrDefault();
		}

		protected override Func<TypeOfDepartment, bool> AdditionalCheckingWhenAdding(TypeOfDepartmentBindingModel model) =>
			x => x.Title == model.Title;

		protected override Func<TypeOfDepartment, bool> AdditionalCheckingWhenUpdateing(TypeOfDepartmentBindingModel model) =>
			x => x.Title == model.Title && x.Id != model.Id;

		protected override IQueryable<TypeOfDepartment> GetListForDelete(IQueryable<TypeOfDepartment> query, TypeOfDepartmentSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}

			return query;
		}

		protected override TypeOfDepartmentViewModel ConvertToViewModel(TypeOfDepartment entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title
			};

		protected override TypeOfDepartment ConvertToEntityModel(TypeOfDepartmentBindingModel model, TypeOfDepartment element)
		{
			element.Title = model.Title;

			return element;
		}
	}
}